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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Caching.Memory;
using Common;
using RecruitWeb.Token;
using RecruitWeb.Configuration;

namespace RecruitWeb
{

    /// <summary>
    /// 尽量减少初始化代码的操作, 否则第一次启动会卡顿, 数据库初始化只会在第一次部署才执行
    /// </summary>
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
            Config.configuration = Configuration;
            services.AddMvc();
            services.AddOptions();
            services.AddResponseCaching();
            services.AddResponseCompression();
            // 加载JwtTokenConfig的配置文件
            services.Configure<JwtTokenConfig>(Configuration.GetSection("JwtTokenConfig"));
            #region 根据配置文件加载不同的数据库
            var DbServerName = Configuration.GetValue<string>("DbServerName");
            switch (DbServerName)
            {
                case "npgsql":
                    services.AddDbContext<RecruitDbContext>(option => option.UseNpgsql(Configuration.GetValue<string>("npgsql_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
                    break;
                case "sqlserver":
                    services.AddDbContext<RecruitDbContext>(option => option.UseSqlServer(Configuration.GetValue<string>("sqlserver_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
                    break;
                case "mysql":
                    services.AddDbContext<RecruitDbContext>(option => option.UseMySQL(Configuration.GetValue<string>("mysql_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
                    break;

                default:
                    // 默认使用mysql
                    services.AddDbContext<RecruitDbContext>(option => option.UseNpgsql(Configuration.GetValue<string>("mysql_connstr"), b => b.MigrationsAssembly("RecruitWeb")));
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
            app.UseResponseCaching();
            app.UseResponseCompression();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            #region 自动创建数据库, 并且初始化测试数据, 创建唯一键和索引等
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetService<RecruitDbContext>();
                    var hasCreated = dbContext.Database.EnsureCreated();    // 这个代码是发布以后方便其他的一件部署的功能
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
            #endregion

        }
    }
}
