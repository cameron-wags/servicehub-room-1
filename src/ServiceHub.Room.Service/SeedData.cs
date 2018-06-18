using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Repository;

namespace ServiceHub.Room.Service
{
    public static class SeedData
    {
        private static ILogger logger;

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<RoomsRepository>();

            // No initialization necessary
            if (context.GetAsync().Result.Any()) return;

            logger = ServiceLogging.Create();

            try
            {
                await context.InsertAsync(new Context.Models.Room()
                    { });
            }
            catch(Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }
    }
}
