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
using Sol_Demo.Implementation;
using Sol_Demo.Interface;

namespace Sol_Demo
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

            services.AddTransient<ServiceA>();
            services.AddTransient<ServiceB>();

            services.AddTransient<Func<ImplementationType, IService>>(
                (leServiceProvider => leImplementationType => {

                    IService service = null;

                    switch (leImplementationType)
                    {
                        case ImplementationType.ServiceA:
                            service =leServiceProvider.GetService<ServiceA>();
                            break;

                        case ImplementationType.ServiceB:
                            service =leServiceProvider.GetService<ServiceB>();
                            break;
                    }

                    return service;
                })


                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
