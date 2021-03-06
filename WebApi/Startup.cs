using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Managers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Managers;

namespace WebApi
{
    public class Startup
    {
        private readonly string corsPolicyName = "myCustomPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // infrastructure.managers
            services.AddSingleton<IAppSettingsManager, AppSettingsManager>();
            services.AddSingleton<IDataReciveManager, DataReciveManager>();

            // repos 
            // ������ ������ ����������� ��� ���������������� � �������, ����� �������� �� Scoped �� ��� ����� ��������� �.�. ��� ��
            services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IRepository<Offer>, OfferRepository>();

            // managers
            services.AddScoped<IOfferManager, OfferManager>();

            // cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicyName,
                    builder =>
                    {
                        builder.WithOrigins(Configuration.GetValue<string>("ClientUrl"))
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            // automapper 
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(/*corsPolicyName*/builder => builder.AllowAnyOrigin());

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
