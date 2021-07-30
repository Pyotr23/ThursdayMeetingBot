using ThursdayMeetingBot.Libraries.Core.Models.Entities.Base;

namespace ThursdayMeetingBot.Libraries.Core.Models.Entities
{
    /// <summary>
    ///     Base user model.
    /// </summary>
    public record UserBase : AggregatedEntity<int>
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