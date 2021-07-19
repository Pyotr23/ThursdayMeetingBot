using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Extensions;
using ThursdayMeetingBot.Web.Interfaces;
using ThursdayMeetingBot.Web.Services;

namespace ThursdayMeetingBot.Web
{
    /// <summary>
    ///     Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Configuration of web application.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="configuration"> IConfiguration instance. </param>
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        ///     Method for configure web app services.
        /// </summary>
        /// <param name="services"> Web app services collection. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurationSections(Configuration);
            
            services.AddHttpClient(HttpClientConstant.Name, 
                hc => hc.BaseAddress = new Uri(HttpClientConstant.UriString));
         
            services.AddSingleton<IBotService, BotService>();
            services.AddScoped<IBotMessageService, BotMessageService>();
            services.AddMediatR(typeof(Startup));

            services
                .AddControllers()
                .AddNewtonsoftJson();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"> IApplication Builder object. </param>
        /// <param name="env"> IWwbHostEnvironment object. </param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(erp => erp.MapControllers());
        }
    }
}