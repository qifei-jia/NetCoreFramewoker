﻿using Hk.Core.Data.DbContextCore;
using Hk.Core.Data.DbContextCore.DbTypeContext;
using Hk.Core.Util.Dependency;
using Hk.Core.Util.Helper;
using Microsoft.Extensions.DependencyInjection;
using DbContextOption = Hk.Core.Data.Options.DbContextOption;

namespace Hk.Core.Web.Config
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar
    {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Regist(IServiceCollection services)
        {
            #region 配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();//指定处理cookie
                });
            });
            #endregion

            #region 配置DbContextOption
            //database connectionstring
            var dbConnectionString = ConfigHelper.GetConnectionString("BaseDb");
            //配置DbContextOption
            services.Configure<DbContextOption>(options =>
            {
                options.ConnectionString = dbConnectionString;
                options.ModelAssemblyName = "Hk.Core.Entity";
            });
            services.AddTransient<IDbContextCore, SqlServerDbContext>(); //注入EF上下文

            #endregion
        }
    }
}