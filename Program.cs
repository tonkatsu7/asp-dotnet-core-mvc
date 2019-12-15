using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asp_dotnet_core_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    webBuilder.ConfigureLogging(
                        builder =>
                        {
                            // Providing an instrumentation key here is required if you're using
                            // standalone package Microsoft.Extensions.Logging.ApplicationInsights
                            // or if you want to capture logs from early in the application startup
                            // pipeline from Startup.cs or Program.cs itself.
                            builder.AddApplicationInsights("945136f4-4296-44e2-8bb2-1060a71c6e33");

                            // Optional: Apply filters to control what logs are sent to Application Insights.
                            // The following configures LogLevel Information or above to be sent to
                            // Application Insights for all categories.
                            builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                                                ("", LogLevel.Trace);
                        }
                    );
                });
    }
}
