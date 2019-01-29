using Demo.AhphOcelot.Cache;
using Demo.AhphOcelot.Configuration;
using Demo.AhphOcelot.DataBase.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Cache;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AhphOcelot.Middleware
{
    /// <summary>
    /// 扩展Ocelot 实现自定义的注入
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加默认的注入方式，所有需要传入的参数都是用默认值
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static IOcelotBuilder AddAhphOcelot(this IOcelotBuilder builder, Action<AhphOcelotConfiguration> option)
        {
            builder.Services.Configure(option);
            //配置信息
            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<AhphOcelotConfiguration>>().Value);
            //配置文件仓储注入
            builder.Services.AddSingleton<IFileConfigurationRepository, SqlServerFileConfigurationRepository>();
            //注册后端服务
            builder.Services.AddHostedService<DbConfigurationPoller>();
            //使用Redis重写缓存
            builder.Services.AddSingleton<IOcelotCache<FileConfiguration>, InRedisCache<FileConfiguration>>();
            builder.Services.AddSingleton<IOcelotCache<CachedResponse>, InRedisCache<CachedResponse>>();

            //配置文件写入Redis
            builder.Services.AddSingleton<IInternalConfigurationRepository, RedisInternalConfigurationRepository>();

            return builder;
        }

    }
}
