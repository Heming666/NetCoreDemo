﻿using Business.IService.Customer;
using Microsoft.EntityFrameworkCore;
using Repository.Entity.Models.Consume;
using Repository.Entity.ViewModels.Index;
using Repository.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Customer
{
    public class ComsumeService : BaseService<ConsumeEntity>, IComsumeService
    {
        public ComsumeService(IRepositoryFactory repositoryFactory, DbContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
        }

        public void Add(ConsumeEntity entity)
        {
            this.Repository.Add(entity);
        }

        public List<ConsumeEntity> GetList(Expression<Func<ConsumeEntity, bool>> expression)
        {
            return this.Repository.Where(expression).ToList();
        }

        public async Task<List<ChartsColumnModel>> LoadColumn(Expression<Func<ConsumeEntity, bool>> expression)
        {
            var data = await this.Repository.Where(expression).GroupBy(x => new { x.Classify, Month = x.LogTime.Month }, (x, y) => new { Total = y.Sum(p => p.Amount), Classify = x.Classify, x.Month }).Select(x => x).ToListAsync();
            var classifyGroup = data.GroupBy(x => x.Classify).Select(x => new { x.Key, monthDatas = x }).ToList();
            List<ChartsColumnModel> charts = new();
            classifyGroup.ForEach(x =>
            {
                ChartsColumnModel chartsColumn = new ChartsColumnModel(Enum.GetName(x.Key));
                int month = 1;
                while (month < 13)
                {
                    if (x.monthDatas.Any(p => p.Month == month))
                        chartsColumn.data.Add(x.monthDatas.FirstOrDefault(p => p.Month == month).Total);
                    else
                        chartsColumn.data.Add(0);
                    month++;
                }

                charts.Add(chartsColumn);
            });

            var monthTotal = data.GroupBy(x => x.Month, (x, y) => new { Month = x, Total = y.Sum(p => p.Total) }).Select(x => x).ToList();

            ChartsColumnModel chartsColumn = new ChartsColumnModel("总消费");
            int month = 1;
            while (month < 13)
            {
                if (monthTotal.Any(p => p.Month == month))
                    chartsColumn.data.Add(monthTotal.FirstOrDefault(p => p.Month == month).Total);
                else
                    chartsColumn.data.Add(0);
                month++;
            }
            charts.Add(chartsColumn);
            return charts;
        }

        /// <summary>
        /// 统计各项支出的情况
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<ChartsPieModel>> LoadPie(Expression<Func<ConsumeEntity, bool>> expression)
        {
            var data = await this.Repository.Where(expression).GroupBy(x => x.Classify, (x, y) => new { Total = y.Sum(p => p.Amount), Classify = x }).Select(x => x).ToListAsync();
            return data.Select(x => new ChartsPieModel(Enum.GetName(x.Classify), x.Total)).ToList();
        }
    }
}