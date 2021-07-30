using Telegram.Bot.Types;

namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     User DTO.
    /// </summary>
    public record UserDto : DtoBase<int>
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

        public UserDto(User telegramUser) => (Id, FirstName, LastName, Username)
            = (telegramUser.Id, telegramUser.FirstName, telegramUser.LastName, telegramUser.Username);

        public UserDto()
        {
            
        }
    }
}