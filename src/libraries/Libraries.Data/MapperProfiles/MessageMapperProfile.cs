using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    public class MessageMapperProfile : Profile
    {
        public MessageMapperProfile()
        {
            CreateMap<MessageDto, Message>(MemberList.Source)
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore());
        }
    }
}