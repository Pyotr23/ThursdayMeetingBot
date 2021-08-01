using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThursdayMeetingBot.Libraries.Core.Models.BaseEntities.Common;

namespace ThursdayMeetingBot.Libraries.Core.Models.BaseEntities
{
    /// <summary>
    ///     Base type of the chat.
    /// </summary>
    public record ChatTypeBase<TKey> : AggregatedEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        /// <inheritdoc cref="AggregatedEntity{TKey}"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override TKey Id { get; set; }
        
        /// <summary>
        ///     Alias.
        /// </summary>
        public string Alias { get; set; }
    }
}