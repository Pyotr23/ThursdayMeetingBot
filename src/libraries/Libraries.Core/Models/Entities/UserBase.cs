using System;
using ThursdayMeetingBot.Libraries.Core.Models.Entities.Base;

namespace ThursdayMeetingBot.Libraries.Core.Models.Entities
{
    /// <summary>
    ///     Base user model.
    /// </summary>
    /// <typeparam name="TKey"> Type of entity unique index. </typeparam>
    public record UserBase<TKey> : AggregatedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Unique identifier of user in Telegram.
        /// </summary>
        public int TelegramId { get; set; }

        /// <summary>
        ///     User name that starts with "@".
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     User first name.
        /// </summary>
        /// 
        public string FirstName { get; set; }

        /// <summary>
        ///     User last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Unique identifier of telegram chat for current user.
        /// </summary>
        public long TelegramChatId { get; set; }
    }
}