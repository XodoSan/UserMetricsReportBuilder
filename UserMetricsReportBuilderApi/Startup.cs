using Application;
using Application.Generator;
using Application.Engine;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace UserMetricsReportBuilderApi
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
            services.AddScoped<IMetricRepository, MetricRepository>();
            services.AddScoped<IPropertySegmentRepository, PropertySegmentRepository>();
            services.AddScoped<IFilterEngine, FilterEngine>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExcelGenerator, ExcelGenerator>();
            services.AddScoped<IExcelFileResultGenerator, ExcelFileResultGenerator>();

            IConfiguration config = GetConfig();
            string connectionString = config.GetConnectionString("Reports");
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("UserMetricsReportBuilderApi")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
