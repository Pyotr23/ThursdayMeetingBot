using System;

namespace ThursdayMeetingBot.Libraries.Core.Models.Common
{
    /// <summary>
    ///     Base model for aggregated entities.
    /// </summary>
    /// <typeparam name="TKey"> Type of entity unique index. </typeparam>
    public abstract record AggregatedEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Unique identifier.
        /// </summary>
        public abstract TKey Id { get; set; }
        
        /// <summary>
        ///     Created date.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        ///     Updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}