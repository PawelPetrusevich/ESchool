using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ESchool
{
    using System;

    using ESchool.Properties;

    using Microsoft.Extensions.DependencyModel;

    using Serilog;
    using Serilog.Events;

    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole()
                .CreateLogger();

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
                .Build();
    }
}
