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
        ///     Username that starts with "@".
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     User first name.
        /// </summary>
        /// 
        public string FirstName { get; set; }

        /// <summary>
        ///     User last name.
        /// </summary>
        public string LastName { get; set; }
    }
}