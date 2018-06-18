using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceHub.Room.Service
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var building = BuildWebHost(args);

            using (var scope = building.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

            building.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights(Environment.GetEnvironmentVariable("INSTRUMENTATION_KEY"))
                .UseStartup<Startup>()
                .Build();
    }

}