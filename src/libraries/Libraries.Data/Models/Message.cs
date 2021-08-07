using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ThursdayMeetingBot.Libraries.Core.Models.Common;

namespace ThursdayMeetingBot.Libraries.Data.Models
{
    /// <summary>
    ///     Message.
    /// </summary>
    [Index(nameof(MessageId), nameof(ChatId), IsUnique = true)]
    public record Message : AggregatedEntity<long>
    {
        /// <inheritdoc cref="AggregatedEntity{TKey}"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }
        
        [MaxLength(512)]
        public string Text { get; set; }
        
        public int MessageId { get; set; }
        
        public long ChatId { get; set; }
        
        public Chat Chat { get; set; }
        
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}