using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(LogBuilder =>
            {
                LogBuilder.AddConsole();
                LogBuilder.SetMinimumLevel(LogLevel.Trace);
            });
            services.AddScoped<Test1>();
            
            using (var sp = services.BuildServiceProvider())
            {
                var test1 = sp.GetRequiredService<Test1>();
                test1.Test();
            }
        }
    }
}
