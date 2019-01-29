using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Demo.AhphOcelot.Middleware;
using IdentityServer4.AccessTokenValidation;
using System;
using Ocelot.Administration;

namespace Demo.AuthPlatform.Gateway
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
            Action<IdentityServerAuthenticationOptions> options = o =>
            {
                o.Authority = "http://localhost:2000"; //IdentityServer地址
                o.RequireHttpsMetadata = false;
                o.ApiName = "api"; //网关管理的名称，对应的为客户端授权的scope
            };
            services.AddOcelot().AddAhphOcelot(option =>
            {
                option.DbConnectionStrings = "User ID=_pgAdmin_;Password=adm@xx.loc;Host=10.0.0.104;Port=5432;Database=Demo.Ocelot";
                option.RedisKeyPrefix = "ddd";
                option.RedisConnectionStrings = new System.Collections.Generic.List<string>() { "10.0.0.171:6379,defaultDatabase=0,poolsize=50,ssl=false,writeBuffer=10240,connectTimeout=1000,connectRetry=1;" };
                //option.EnableTimer = true;
                //option.TimerDelay = 10000;

            }).AddAdministration("/CtrOcelot", options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAhphOcelot().Wait();
        
        }
    }
}
