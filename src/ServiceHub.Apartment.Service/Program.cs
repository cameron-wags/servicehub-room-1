﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceHub.Apartment.Service.Controllers;

namespace ServiceHub.Apartment.Service
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var queueController = new QueueController();

      BuildWebHost(args).Run();
      queueController.UseMessagingQueue();
    }

    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseApplicationInsights(Environment.GetEnvironmentVariable("INSTRUMENTATION_KEY"))
        .UseStartup<Startup>()
        .Build();
  }
}
