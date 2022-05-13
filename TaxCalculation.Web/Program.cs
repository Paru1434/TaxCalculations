using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace TaxCalculation
{
    public class Program
    {
        private static IConfiguration _configuration;
        public static int Main(string[] args)
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables().Build();

            try
            {
                Log.Information("Starting web host");

                BuildWebHost(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return CreateWebHostBuilder(args).Build();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => { config.AddConfiguration(_configuration); })
                .UseStartup<Startup>()
                .UseSerilog();
        }
    }
}
