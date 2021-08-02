using System.Collections.Generic;

namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     DTO of chat.
    /// </summary>
    public record ChatDto : DtoBase<long>
    {
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
        public ChatTypeDto ChatType { get; set; }
        
        /// <summary>
        ///     User collection.
        /// </summary>
        public ICollection<UserDto> Users { get; set; }
    }
}