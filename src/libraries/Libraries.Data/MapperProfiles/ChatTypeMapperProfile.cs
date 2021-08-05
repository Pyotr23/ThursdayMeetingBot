using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    /// <summary>
    ///     Profile class for mapper chat type models.
    /// </summary>
    public class ChatTypeMapperProfile : Profile
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public ChatTypeMapperProfile()
        {
            CreateMap<ChatType, ChatTypeDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}