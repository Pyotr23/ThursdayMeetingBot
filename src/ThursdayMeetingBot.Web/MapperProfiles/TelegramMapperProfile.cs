using AutoMapper;
using Telegram.Bot.Types;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Web.MapperProfiles
{
    /// <summary>
    ///     Profile for mapping of telegram entities to DTO.
    /// </summary>
    public class TelegramMapperProfile : Profile
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public TelegramMapperProfile()
        {
            CreateMap<User, UserDto>(MemberList.Destination);
            CreateMap<Chat, ChatDto>(MemberList.Destination)
                .ForPath(dest => dest.ChatType.Alias,
                    opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.Users, 
                    opt => opt.Ignore());
        }
    }
}