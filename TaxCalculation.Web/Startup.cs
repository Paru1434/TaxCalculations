using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using TaxCalculation.Repository.DBContext;
using TaxCalculation.Repository.Impl;
using TaxCalculation.Repository.Interfaces;
using TaxCalculation.Services.Impl;
using TaxCalculation.Services.Interfaces;

namespace TaxCalculation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                   options => options.UseNpgsql(
                        _configuration["DataStorage:PostgreSql:ConnectionStrings:DefaultConnection"],
                       optionsAction => { optionsAction.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name); })
                       .EnableSensitiveDataLogging()
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                   );

            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                 .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                 = new DefaultContractResolver());

            services.AddControllers();
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen();
            services.AddScoped<ITaxCalculationService, TaxCalculationService>();
            services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tax Calculation App v1");
            });
            app.UseAuthorization();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
