using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Implementations;
using BLL.Contracts;
using BLL.Implementation;

namespace WebAPI
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
            // Mapper
            services.AddAutoMapper(typeof(Startup));

            // DataAccess
            services.AddDbContext<ApplicationContext>();
            services.Add(new ServiceDescriptor(typeof(IPersonDataAccess), typeof(PersonDataAccess), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IParkingPlaceDataAccess), typeof(ParkingPlaceDataAccess), ServiceLifetime.Scoped));

            // person Services BLL
            services.Add(new ServiceDescriptor(typeof(IPersonCreateService), typeof(PersonCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonGetService), typeof(PersonGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonUpdateService), typeof(PersonUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonDeleteService), typeof(PersonDeleteService), ServiceLifetime.Scoped));

            // place Services BLL
            services.Add(new ServiceDescriptor(typeof(IPersonCreateService), typeof(ParkingPlaceCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IParkingPlaceGetService), typeof(ParkingPlaceGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IParkingPlaceUpdateService), typeof(ParkingPlaceUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IParkingPlaceDeleteService), typeof(ParkingPlaceDeleteService), ServiceLifetime.Scoped));

            services.AddControllers();
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
