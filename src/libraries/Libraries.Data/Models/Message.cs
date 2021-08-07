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
        
        /// <summary>
        ///     The actual UTF-8 text
        /// </summary>
        [MaxLength(512)]
        public string Text { get; set; }
        
        /// <summary>
        ///     Unique message identifier.
        /// </summary>
        public int MessageId { get; set; }
        
        /// <summary>
        ///     Chat identifier.
        /// </summary>
        public long ChatId { get; set; }
        
        /// <summary>
        ///     Conversation the message belongs to.
        /// </summary>
        public Chat Chat { get; set; }
        
        /// <summary>
        ///     Sender identifier.
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        ///     Sender.
        /// </summary>
        public User User { get; set; }
    }
}