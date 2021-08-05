using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThursdayMeetingBot.Libraries.Core.Models.Common;

namespace ThursdayMeetingBot.Libraries.Data.Models
{
    /// <summary>
    ///     Chat.
    /// </summary>
    public record Chat : AggregatedEntity<long>
    {
        /// <inheritdoc cref="AggregatedEntity{TKey}"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }
        
        /// <summary>
        ///     Title (not for private).
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        ///     First name (for private only).
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Last name (for private only).
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        ///     Username (for private only).
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        ///     Chat type ID.
        /// </summary>
        public int ChatTypeId { get; set; }
        
        /// <summary>
        ///     Chat type.
        /// </summary>
        public ChatType ChatType { get; set; }

        /// <summary>
        ///     User collection.
        /// </summary>
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}