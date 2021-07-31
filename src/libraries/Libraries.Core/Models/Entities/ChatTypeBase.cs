using ThursdayMeetingBot.Libraries.Core.Models.Entities.Base;

namespace ThursdayMeetingBot.Libraries.Core.Models.Entities
{
    /// <summary>
    ///     Base type of the chat.
    /// </summary>
    public record ChatTypeBase : AggregatedEntity<int>
    {
        /// <summary>
        ///     Alias.
        /// </summary>
        public string Alias { get; set; }
    }
}