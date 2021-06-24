using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThursdayMeetingBot.TelegramBot.Configurations;
using ThursdayMeetingBot.TelegramBot.Constants;
using ThursdayMeetingBot.TelegramBot.Interfaces;
using ThursdayMeetingBot.TelegramBot.Services;

namespace ThursdayMeetingBot.TelegramBot
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
            var section = Configuration.GetSection(nameof(BotConfiguration));
            services.Configure<BotConfiguration>(section);
            
            services.AddHttpClient(HttpClientConstant.Name, 
                hc => hc.BaseAddress = new Uri(HttpClientConstant.UriString));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IBotService, BotService>()
                .AddScoped<IBotMessageService, BotMessageService>();
            //     .AddScoped<IRequestHandler<StartCommand, Unit>, StartCommandHandler<UserDto, Guid>>();

            services.AddControllers();
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