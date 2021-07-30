using System;

namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     User DTO.
    /// </summary>
    public record UserDto<TKey> : DtoBase<TKey> 
        where TKey : IEquatable<TKey>
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