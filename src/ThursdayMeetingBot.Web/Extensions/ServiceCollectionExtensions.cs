using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Quartz.Spi;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Libraries.Core.Services.Quartz;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram.Entity;
using ThursdayMeetingBot.Libraries.Core.Services.Wikipedia;
using ThursdayMeetingBot.Libraries.Data.MapperProfiles;
using ThursdayMeetingBot.Libraries.Quartz.Jobs;
using ThursdayMeetingBot.Libraries.Quartz.Jobs.Factory;
using ThursdayMeetingBot.Libraries.Services.Quartz;
using ThursdayMeetingBot.Libraries.Services.Telegram;
using ThursdayMeetingBot.Libraries.Services.Telegram.Entity;
using ThursdayMeetingBot.Libraries.Wikipedia.Services;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Helpers;
using ThursdayMeetingBot.Web.MapperProfiles;

namespace ThursdayMeetingBot.Web.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddConfigurationSections(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var section = configuration.GetSection(nameof(NotificationConfiguration));
            services.Configure<NotificationConfiguration>(section);
            
            section = configuration.GetSection(nameof(BotConfiguration));
            services.Configure<BotConfiguration>(section);

            return services;
        }

        internal static IServiceCollection AddDbContexts<T>(
            this IServiceCollection services,
            IConfiguration configuration) where T : DbContext
        {
            const string migrationAssembly = AssemblyConstant.MigrationAssemblyName;
            
            
            void PostgreOptionsAction(NpgsqlDbContextOptionsBuilder builder) 
                => builder.MigrationsAssembly(migrationAssembly);
            
            var connectionString = configuration
                .GetSection(nameof(DbConfiguration))
                .Get<DbConfiguration>()
                .ConnectionString;
            
            void DbContextOptionsAction(DbContextOptionsBuilder builder) 
                => builder.UseNpgsql(connectionString, PostgreOptionsAction);
                
            return services                
                .AddEntityFrameworkSqlite()
                .AddDbContext<T>();
        }

        internal static IServiceCollection AddServices<TDbContext>(
            this IServiceCollection services)
            where TDbContext : DbContext
        {
            services.TryAddScoped<IUserService, UserService<TDbContext>>();
            services.TryAddScoped<IChatService, ChatService<TDbContext>>();
            services.TryAddScoped<IChatTypeService, ChatTypeService<TDbContext>>();
            services.TryAddScoped<IMessageService, MessageService<TDbContext>>();
            
            services.TryAddSingleton<IBotService, BotService>();
            services.TryAddSingleton<IQuartzService, QuartzService>();
            services.TryAddSingleton<IWikiService, WikiService>();

            return services;
        }
        
        internal static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            return services
                .AddSingleton<IJobFactory, JobFactory>()
                .AddSingleton(StdSchedulerHelper.GetScheduler)
                .AddTransient<TextNotificationJob>();
        }
        
        internal static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            services
                .AddAutoMapper(configuration =>
                {
                    configuration.AddProfile<UserMapperProfile>();
                    configuration.AddProfile<ChatMapperProfile>();
                    configuration.AddProfile<ChatTypeMapperProfile>();
                    configuration.AddProfile<MessageMapperProfile>();

                    configuration.AddProfile<TelegramMapperProfile>();
                });
        }
    }
}