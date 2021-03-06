using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ThursdayMeetingBot.Libraries.Data.Helpers;
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
        ///     Table with types of chats.
        /// </summary>
        public DbSet<ChatType> ChatTypes { get; set; }
        
        /// <summary>
        ///     Table with chats.
        /// </summary>
        public DbSet<Chat> Chats { get; set; }
        
        /// <summary>
        ///     Table with messages.
        /// </summary>
        public DbSet<Message> Messages { get; set; }
    }
}