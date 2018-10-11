using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnet_essentials
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ThreadPool.SetMaxThreads(10, 100);
            new Thread(LogThreads) { IsBackground = true }.Start();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void LogThreads(object _)
        {
            while (true)
            {
                ThreadPool.GetAvailableThreads(out var availableThreads, out var _);
                ThreadPool.GetMaxThreads(out var maxThreads, out var _);
                ThreadPool.GetMinThreads(out var minThreads, out var _);
                Console.WriteLine($"Avail: {availableThreads}, Active: {maxThreads - availableThreads}, Max: {maxThreads}.");
                Thread.Sleep(1000);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .Build();
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureLogging(builder =>
                    {
                        builder.AddConfiguration(config.GetSection("Logging"));
                    });
        }
    }
}
