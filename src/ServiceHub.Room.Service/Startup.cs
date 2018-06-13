﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceHub.Room.Context.Repository;

namespace ServiceHub.Room.Service
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddSingleton<IQueueClient>(qc => 
      //  new QueueClient(
      //    Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING"),
      //    Environment.GetEnvironmentVariable("SERVICE_BUS_QUEUE_NAME")
      //  )
      //);
      
      services.AddScoped<IRoomsRepository, RoomRepositoryMemory>();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddApplicationInsights(app.ApplicationServices);
      
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      
      app.UseMvc();
    }
  }
}
