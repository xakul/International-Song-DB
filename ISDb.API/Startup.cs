using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ISDb.Application.Util;
using ISDb.Application;
using ISDb.Domain.Mssql.Poco;
using Microsoft.EntityFrameworkCore;
using ISDb.API.Util;

namespace ISDb.API
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

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "International Song Database",
                    Description = "A simple example ASP.NET Core Web API",
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowCredentials()
                           .AllowAnyHeader()
                           .SetIsOriginAllowed(_ => true);
                });
            });

            MapperConfiguration config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserModelViewProfile());
            });

            services.AddSingleton(config.CreateMapper());

            RegisterServices(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowMyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ISDb v1");
                c.RoutePrefix = string.Empty;
            });

        }

        private void RegisterServices(IServiceCollection services)
        {
            
            services.AddDbContext<BaseContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BaseContext"]));
            services.AddScoped<ServiceEngine>();


        }
    }
}
