using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using HeroDemo.Application;
using HeroDemo.Repository;
using MongoDB.Bson.Serialization.Conventions;

namespace HeroDemo
{
    public class Settings
    {
        public string Database {get;set;}
        public string MongoConnection {get;set;} 
    }
    
    public class Startup
    {
        
       
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddJsonFile("web-config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
           // Add framework services.
           services.AddCors(
               options => 
                {
                    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
                }
           );
           
           services.AddMvc().AddJsonOptions(options =>{
               options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
           });
            
     
           services.AddInstance<IMongoDatabase>(ConnectDB());
           services.AddSingleton<IHeroRepository,HeroRepository>();
           services.AddSingleton<IHeroApplication, HeroApplication>();     
        }
        
        private IMongoDatabase ConnectDB()
        {
            var mongoSection = Configuration.GetSection("MongoDB");
            var client = new MongoClient(mongoSection.GetSection("ConnectionString").Value);
            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camel case", pack, t => true);
            return client.GetDatabase(mongoSection.GetSection("Database").Value);           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
    
            var section = Configuration.GetSection("MongoDB");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler();
            app.UseCors("AllowAll");
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name:"api",
                  template: "api/{controller}/{id?}"  
                );
             });
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
