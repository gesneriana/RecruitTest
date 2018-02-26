using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruit.Models;
using Microsoft.EntityFrameworkCore;
using Recruit.Data;

namespace RecruitWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            #region 根据配置文件加载不同的数据库
            var DbServerName = Configuration.GetValue<string>("DbServerName");
            switch (DbServerName)
            {
                case "npgsql":
                    services.AddDbContext<RecruitDbContext>(option => option.UseNpgsql(Configuration.GetValue<string>("npgsql_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
                    break;
                case "sqlserver":
                    services.AddDbContext<RecruitDbContext>(option => option.UseNpgsql(Configuration.GetValue<string>("sqlserver_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
                    break;
                case "mysql":
                    services.AddDbContext<RecruitDbContext>(option => option.UseNpgsql(Configuration.GetValue<string>("mysql_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
                    break;

                default:
                    // 默认使用mysql
                    services.AddDbContext<RecruitDbContext>(option => option.UseNpgsql(Configuration.GetValue<string>("mysql_connstr")));
                    break;
            }
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetService<RecruitDbContext>();
                    var hasCreated = dbContext.Database.EnsureCreated();
                    if (hasCreated)
                    {
                        var dbInitializer = new RecruitWebSampleDataInitializer(dbContext);
                        dbInitializer.InitTableSchema().Wait();
                        dbInitializer.InitDatabaseData().Wait();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
