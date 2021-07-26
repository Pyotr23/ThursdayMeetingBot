using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using ThursdayMeetingBot.Libraries.Data.Configurations;
using ThursdayMeetingBot.Libraries.Data.Contexts;
using ThursdayMeetingBot.Web.Configurations;

namespace ThursdayMeetingBot.Web.Extensions
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
            var migrationAssembly = typeof(BotDbContext)
                .GetTypeInfo()
                .Assembly
                .GetName()
                .Name;

            void PostgreOptionsAction(NpgsqlDbContextOptionsBuilder builder) 
                => builder.MigrationsAssembly(migrationAssembly);

            var connectionString = configuration
                .GetSection(nameof(DbConfiguration))
                .Get<DbConfiguration>()
                .ConnectionString;

            void DbContextOptionsAction(DbContextOptionsBuilder builder) 
                => builder.UseNpgsql(connectionString, PostgreOptionsAction);

            return services.AddDbContext<T>(DbContextOptionsAction);
        }
    }
}