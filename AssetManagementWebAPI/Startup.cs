using AssetManagementWebAPI.Business_Logic_Layer.Interfaces;
using AssetManagementWebAPI.Business_Logic_Layer.Services;
using AssetManagementWebAPI.Data_Access_Layer;
using AssetManagementWebAPI.Data_Access_Layer.Context;
using AssetManagementWebAPI.Data_Access_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI
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
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ISoftwareRepository, SoftwareRepository>();
            services.AddScoped<IHardwareRepository, HardwareRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ISoftwareService, SoftwareService>();
            services.AddScoped<IHardwareService, HardwareService>();
            services.AddDbContext<AssetDBContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MyConnStr"));
                }
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssetManagementWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssetManagementWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
