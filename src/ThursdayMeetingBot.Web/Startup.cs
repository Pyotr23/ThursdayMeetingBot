using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Contexts;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Extensions;
using ThursdayMeetingBot.Web.MediatR.Commands;
using ThursdayMeetingBot.Web.MediatR.Handlers;

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
            services
                .AddConfigurationSections(Configuration)
                .AddDbContexts<BotDbContext>(Configuration)
                .AddServices<BotDbContext>()
                .AddAutoMapperProfiles();

            services.AddHttpClient(HttpClientConstant.Name, 
                hc => hc.BaseAddress = new Uri(HttpClientConstant.UriString));
         
            services
                .AddScoped<IRequestHandler<UpdateCommand, Unit>, UpdateCommandHandler>()
                .AddScoped<IRequestHandler<StartCommand, Unit>, StartCommandHandler<UserDto>>();

            services
                .AddQuartz()
                .AddMediatR(typeof(Startup))
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

            app
                .UseRouting()
                .UseCors()
                .UseEndpoints(erp => erp.MapControllers())
                .StartScheduler();
        }
    }
}