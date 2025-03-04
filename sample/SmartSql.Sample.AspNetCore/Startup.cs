﻿using System;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartSql.InvokeSync.RabbitMQ;
using SmartSql.Sample.AspNetCore.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartSql.Sample.AspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // services.AddSkyApmExtensions().AddSmartSql();
            services.AddControllers();
            services
                .AddSmartSql((sp, builder) =>
                {
                    builder.UseProperties(Configuration);
                    
                    
//                    var subscriber = sp.GetRequiredService<ISubscriber>();
//                    builder.UseCacheManager(new SyncCacheManager(subscriber));
                })
                .AddRepositoryFromAssembly(o =>
                {
                    //o.AssemblyString = "SmartSql.Sample.AspNetCore";
                    //o.Filter = (type) => type.Namespace == "SmartSql.Sample.AspNetCore.DyRepositories";
                    o.AssemblyString = "SmartSql.Sample.Repos";
                    o.Filter = (type) => type.Namespace == "SmartSql.Sample.Repos";
                })
                **/;
                // .AddInvokeSync(options => { })
                // .AddRabbitMQPublisher(options =>
                // {
                //     options.HostName = "localhost";
                //     options.UserName = "guest";
                //     options.Password = "guest";
                //     options.Exchange = "smartsql";
                //     options.RoutingKey = "smartsql.sync";
                //
                // });
//                .AddRabbitMQSubscriber(options =>
//                {
//                    options.HostName = "localhost";
//                    options.UserName = "maidao";
//                    options.Password = "maidao";
//                    options.Exchange= "data.sync";            
//                    options.RoutingKey = "eq";
//                    options.QueueName = "data.sync.eq.crm";
//                }).AddRabbitMQSubscriber(options =>
//                {
//                    options.HostName = "localhost";
//                    options.UserName = "maidao";
//                    options.Password = "maidao";
//                    options.RoutingKey = "smartsql-sync-1";
//                    options.QueueName = "second";
//                });

            services.AddSingleton<UserService>();
            services.AddSingleton<CustomerService>();
            
            RegisterConfigureSwagger(services);
            return services.BuildAspectInjectorProvider();
        }

        private void RegisterConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "SmartSql.Sample.AspNetCore",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Url = new Uri("https://github.com/Smart-Kit/SmartSql"),
                        Email = "ahoowang@qq.com",
                        Name = "SmartSql"
                    },
                    Description = "SmartSql.Sample.AspNetCore"
                });
                c.CustomSchemaIds((type) => type.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.ApplicationServices.UseSmartSqlSync();
            // app.ApplicationServices.UseSmartSqlSubscriber((syncRequest) =>
            // {
            //     Console.Error.WriteLine(syncRequest.Scope);
            // });

            app.UseSwagger(c => { });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartSql.Sample.AspNetCore"); });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}