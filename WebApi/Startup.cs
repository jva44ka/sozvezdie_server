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
using Microsoft.Extensions.Hosting;
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
            // инжект общего репозитория для масштабируемости в будущем, лучше заменить на Scoped но нам нужно состояние т.к. нет бд
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
                        builder.WithOrigins(Configuration.GetValue<string>("DataApiUrl"))
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(corsPolicyName);

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
