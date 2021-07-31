using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThursdayMeetingBot.Libraries.Core.Models.Entities;

namespace ThursdayMeetingBot.Libraries.Data.Models
{
    /// <summary>
    ///     Chat type.
    /// </summary>
    public record ChatType : ChatTypeBase
    {
        /// <inheritdoc cref="ChatTypeBase"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
    }
}