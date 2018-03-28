using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ESchool
{
    using System;
    using System.IO;

    using ESchool.Properties;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyModel;

    using Serilog;
    using Serilog.Events;

    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Log.Information(Resources.SuccessfulHostRun);
                BuildWebHost(args).Run();
                return 0;
            }
            catch (Exception e)
            {
                Log.Fatal(e, Resources.LogFatalError);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .ConfigureAppConfiguration(
                    (hostingcontext, config) =>
                        {
                            var currentEnv = hostingcontext.HostingEnvironment;
                            config.AddJsonFile("appsettings.json");
                            config.AddJsonFile($"appsettings.{currentEnv.EnvironmentName}.json", optional: true);
                            config.AddEnvironmentVariables();

                            if (currentEnv.IsDevelopment())
                            {
                                Log.Logger = new LoggerConfiguration()
                                    .MinimumLevel.Debug()
                                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                    .Enrich.FromLogContext()
                                    .WriteTo.ColoredConsole()
                                    .CreateLogger();
                            }
                            else
                            {
                                // Logging file not created
                                Log.Logger = new LoggerConfiguration()
                                    .MinimumLevel.Debug()
                                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                    .Enrich.FromLogContext()
                                    .WriteTo.RollingFile(Path.Combine(hostingcontext.HostingEnvironment.ContentRootPath, "\\logs\\{Date}-log.txt"))
                                    .CreateLogger();
                            }
                        })
                .Build();
    }
}
