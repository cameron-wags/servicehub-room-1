using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ServiceHub.Room.Context.Repository;

namespace ServiceHub.Room.Service {

    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            string remotedb = @"mongodb://cameron-wags:rp7KMfeoIp0KgM7dMMpnZDF9Cmtde0PIlQAQ9pdrpZZaZdO9Pqt9mk8VXl3upDpp2pyrzajfNvOm2JZtqfOzkQ==@cameron-wags.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            string demodb = @"mongodb://db";

            services.AddSingleton(mc =>
                new MongoClient(remotedb).GetDatabase("rooms").GetCollection<Context.Models.Room>("rooms"));

            services.AddTransient<IRoomsRepository, RoomsRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddApplicationInsights(app.ApplicationServices);

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

}