using AutoMapper;
using Telegram.Bot.Types;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Web.MapperProfiles
{
    /// <summary>
    ///     Profile for mapping of telegram entities to DTO.
    /// </summary>
    /// <typeparam name="TUserDto"></typeparam>
    public class TelegramMapperProfile<TUserDto> : Profile
        where TUserDto : UserDto
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public TelegramMapperProfile()
        {
            CreateMap<User, TUserDto>(MemberList.Destination);
        }
    }
}