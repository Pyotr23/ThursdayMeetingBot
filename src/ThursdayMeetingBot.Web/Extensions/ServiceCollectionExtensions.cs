using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Models.Entities;
using ThursdayMeetingBot.Libraries.Core.Services;
using ThursdayMeetingBot.Libraries.Data.Configurations;
using ThursdayMeetingBot.Libraries.Data.Contexts;
using ThursdayMeetingBot.Libraries.Service.Services;
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
            const string migrationAssembly = "ThursdayMeetingBot.Libraries.Data.MigrationStore";

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

        /// <summary>
        ///     Add services for working with database.
        /// </summary>
        /// <typeparam name="TDbContext"> Db context type. </typeparam>
        /// <typeparam name="TDto">  User DTO type. </typeparam>
        /// <typeparam name="TEntity"> User type. </typeparam>
        /// <typeparam name="TKey"> Generic key for user entity. </typeparam>
        /// <param name="services"> IServiceCollection instance. </param>
        /// <returns> Service collection. </returns>
        internal static IServiceCollection AddServices<TDbContext, TDto, TEntity, TKey>(
            this IServiceCollection services)
            where TDbContext : DbContext
            where TDto : UserDto<TKey>
            where TEntity : UserBase<TKey>
            where TKey : IEquatable<TKey>
        {
            services.TryAddScoped<IUserService<TDto, TKey>,
                UserService<TDbContext, TDto, TEntity, TKey>>();

            return services;
        }
    }
}