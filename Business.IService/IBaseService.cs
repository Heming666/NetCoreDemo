﻿using Repository.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService.Base
{
  public   interface IBaseService 
    {
        IRepository<TEntity> CreateService<TEntity>() where TEntity : class, new();
    }
}