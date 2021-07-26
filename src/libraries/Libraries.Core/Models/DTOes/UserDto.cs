namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     User DTO.
    /// </summary>
    public record UserDto
    {
        /// <summary>
        ///     Unique identifier of user in Telegram.
        /// </summary>
        public int TelegramId { get; set; }
        
        /// <summary>
        ///     User name that starts with "@".
        /// </summary>
        public string UserName { get; set; }
        
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
        ///     Unique identifier of telegram chat for current user.
        /// </summary>
        public long TelegramChatId { get; set; }
    }
}