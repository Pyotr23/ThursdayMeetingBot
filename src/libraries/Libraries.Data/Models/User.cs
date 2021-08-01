using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThursdayMeetingBot.Libraries.Core.Models.Common;

namespace ThursdayMeetingBot.Libraries.Data.Models
{
    /// <summary>
    ///     User.
    /// </summary>
    public record User : AggregatedEntity<int>
    {
        /// <inheritdoc cref="AggregatedEntity{TKey}"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        
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
        
        /// <summary>
        ///     Сhats in which the user is a member.
        /// </summary>
        public ICollection<Chat> Chats { get; set; }
    }
}