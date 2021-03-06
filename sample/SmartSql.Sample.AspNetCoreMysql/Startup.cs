using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SmartSql.Sample.AspNetCoreMysql
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
            services.AddControllers();
            services
            .AddSmartSql((sp, builder) =>
            {
                builder.UseProperties(Configuration);
                builder.UseAlias("MySqlTest - " + Guid.NewGuid());
                  //                    var subscriber = sp.GetRequiredService<ISubscriber>();
                  //                    builder.UseCacheManager(new SyncCacheManager(subscriber));
              })
            .AddRepositoryFromAssembly(o =>
            {
                  //o.AssemblyString = "SmartSql.Sample.AspNetCore";
                  //o.Filter = (type) => type.Namespace == "SmartSql.Sample.AspNetCore.DyRepositories";
                  o.AssemblyString = "SmartSql.Sample.AspNetCoreMysql";
                o.Filter = (type) => type.Namespace == "SmartSql.Sample.AspNetCoreMysql.DyRepositories";
            })
            .AddInvokeSync(options => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.UseSmartSqlSync();
            app.ApplicationServices.UseSmartSqlSubscriber((syncRequest) =>
            {
                Console.Error.WriteLine(syncRequest.Scope);
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
