using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    /// <summary>
    ///     Profile class for mapper message models.
    /// </summary>
    public class MessageMapperProfile : Profile
    {
        /// <inheritdoc cref="Profile"/>
        public MessageMapperProfile()
        {
            CreateMap<MessageDto, Message>(MemberList.Source)
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
        }
    }
}