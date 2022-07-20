using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAMCandidateTestAPI_MarkSeno.Data.Interface;
using IAMCandidateTestAPI_MarkSeno.Data;
using Microsoft.EntityFrameworkCore;
using IAMCandidateTestModels_MarkSeno;
using AutoMapper;

namespace IAMCandidateTestAPI_MarkSeno
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
            try
            {
                services.AddDbContext<IAMCandidateDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("IAMCandidateDb"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: int.Parse(Configuration["DatabaseRetryOptions:MaxRetryCount"]),
                            maxRetryDelay: TimeSpan.FromSeconds(int.Parse(Configuration["DatabaseRetryOptions:MaxRetryDelay"])),
                            errorNumbersToAdd: null);
                    })
                );

                services.AddControllers();

                services.AddScoped<IAnimalRepo, AnimalRepo>();
                services.AddScoped<IMineralRepo, MineralRepo>();
                services.AddScoped<IVegetableRepo, VegetableRepo>();


                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IAMCandidateTestAPI_MarkSeno", Version = "v1" });
                });

                // Handle invalid models here instead of check if valid in each call
                services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => new
                        {
                            Name = e.Key,
                            Message = e.Value.Errors.First().ErrorMessage
                        }).ToArray();

                        var errorResponse = new
                        {
                            ValidationError = errors
                        };

                        return new BadRequestObjectResult(errorResponse);
                    };
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IAMCandidateTestAPI_MarkSeno v1"));
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
