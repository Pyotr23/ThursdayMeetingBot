using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Contexts;
using ThursdayMeetingBot.Libraries.Data.MapperProfiles;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Extensions;
using ThursdayMeetingBot.Web.Interfaces;
using ThursdayMeetingBot.Web.MapperProfiles;
using ThursdayMeetingBot.Web.MediatR.Commands;
using ThursdayMeetingBot.Web.MediatR.Handlers;
using ThursdayMeetingBot.Web.Quartz;
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
            services
                .AddConfigurationSections(Configuration)
                .AddDbContexts<BotDbContext>(Configuration)
                .AddServices<BotDbContext>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<UserMapperProfile>();
                config.AddProfile<ChatMapperProfile>();
                config.AddProfile<ChatTypeMapperProfile>();
                config.AddProfile<MessageMapperProfile>();
                
                config.AddProfile<TelegramMapperProfile>();
            });
            
            services.AddHttpClient(HttpClientConstant.Name, 
                hc => hc.BaseAddress = new Uri(HttpClientConstant.UriString));
         
            var scheduler = StdSchedulerFactory
                .GetDefaultScheduler()
                .GetAwaiter()
                .GetResult();
            
            services
                .AddSingleton<IBotService, BotService>()
                .AddScoped<IRequestHandler<UpdateCommand, Unit>, UpdateCommandHandler>()
                .AddScoped<IRequestHandler<StartCommand, Unit>, StartCommandHandler<UserDto>>();
                
            services
                .AddQuartz(q => q.UseMicrosoftDependencyInjectionJobFactory())
                // .AddTransient<TextNotificationJob>()
                // .AddSingleton<IJobFactory>(sp => new JobFactory(sp))
                .AddSingleton<IJobFactory, JobFactory>()
                .AddSingleton(provider =>
                {
                    var stdScheduler = new StdSchedulerFactory()
                        .GetScheduler()
                        .GetAwaiter()
                        .GetResult();

                    stdScheduler.JobFactory = provider.GetService<IJobFactory>(); // new JobFactory(sp);
                     
                    stdScheduler
                        .Start()
                        .GetAwaiter()
                        .GetResult();

                    return stdScheduler;
                })
                .AddTransient<TextNotificationJob>()
                .TryAddSingleton<IQuartzHostedService, QuartzHostedService>();



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