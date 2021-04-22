using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Log;

namespace Demo.Web
{
    /* Configure �� ConfigureServices ֧�ִ��� Configure<EnvironmentName> �� Configure<EnvironmentName>Services �Ļ����ض��汾�� 
     * ��Ӧ����ҪΪ���������ÿ�����������������죩��������ʱ�����ַ����ͷǳ����ã�
     **/
    public class Startup
    {
        /// <summary>
        /// �����ļ�
        /// </summary>
        public IConfiguration _configuration { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public IWebHostEnvironment _env { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<IISServerOptions>(options =>
           {
               options.AllowSynchronousIO = true;
           });
         
            services.AddScoped<LoggerFactory>(logger =>
             {
                 return new NLogService("XmlConfig/NLog.config"); 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();//HTTPS��ת
            app.UseStaticFiles();//��̬�ļ�
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseRequestLocalization();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseResponseCompression();
            app.UseResponseCaching();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute("default", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}