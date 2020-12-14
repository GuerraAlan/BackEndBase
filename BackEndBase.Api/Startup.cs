using System;
using AutoMapper;
using BackEndBase.Anticorruption.AutoMapper;
using BackEndBase.DataAccess.Context;
using BackEndBase.Infra.CrossCutting.Bus;
using BackEndBase.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BackEndBase.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper(typeof(AutoMapperSetup));
            
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? Configuration.GetConnectionString("NpgSqlConnectionString");

            services.AddDbContext<BaseContext>(options =>
                {
                    options.UseNpgsql("Host=postgres;Database=postgres;Username=postgres;Password=Senha1234");
                }
            );

            RegisterServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEndBase.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor accessor, BaseContext dataContext)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEndBase.Api v1"));
            

            dataContext.Database.Migrate();

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }

        public void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}