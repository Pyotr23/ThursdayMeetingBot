using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThursdayMeetingBot.Libraries.Core.Models.Common;

namespace ThursdayMeetingBot.Libraries.Data.Models
{
    /// <summary>
    ///     Chat type.
    /// </summary>
    public record ChatType : AggregatedEntity<int>
    {
        /// <inheritdoc cref="AggregatedEntity{TKey}"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        
        /// <summary>
        ///     Alias.
        /// </summary>
        public string Alias { get; set; }
        
        /// <summary>
        ///     Chats.
        /// </summary>
        public List<Chat> Chats { get; set; }
    }
}