using Microsoft.EntityFrameworkCore;
using ThursdayMeetingBot.Libraries.Data.Extensions;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Data.Contexts
{
    /// <summary>
    ///     Db context for connecting bot data.
    /// </summary>
    public class BotDbContext : DbContext
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="options">Options for creating bot context. </param>
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options) {}
        
        /// <summary>
        ///     Table with users.
        /// </summary>
        public DbSet<User> Users { get; set; }
        
        /// <summary>
        ///     Method executing while models creating.
        /// </summary>
        /// <param name="modelBuilder"> Model builder. </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {

                // Replace table names
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                // Replace column names
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.PrincipalKey.SetName(key.PrincipalKey.GetName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                }
            }
        }
    }
}