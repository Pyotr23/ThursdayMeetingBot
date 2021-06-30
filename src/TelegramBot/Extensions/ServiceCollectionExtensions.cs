using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThursdayMeetingBot.TelegramBot.Configurations;

namespace ThursdayMeetingBot.TelegramBot.Extensions
{
    /// <summary>
    ///     Extensions for IServiceCollection instance.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Add configuration sections.
        /// </summary>
        /// <param name="services"> Service collection. </param>
        /// <param name="configuration"> Configuration. </param>
        /// <returns> Configurated service collection. </returns>
        internal static IServiceCollection AddConfigurationSections(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(nameof(NotificationConfiguration));
            services.Configure<NotificationConfiguration>(section);
            
            section = configuration.GetSection(nameof(BotConfiguration));
            services.Configure<BotConfiguration>(section);

            return services;
        }
    }
}