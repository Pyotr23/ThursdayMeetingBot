using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    /// <summary>
    ///     Profile class for mapper chat models.
    /// </summary>
    public class ChatMapperProfile : Profile
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public ChatMapperProfile()
        {
            CreateMap<Chat, ChatDto>(MemberList.Destination)
                .ForPath(dest => dest.ChatType.Alias,
                    opt => opt.MapFrom(src => src.ChatType.Alias))
                .ForMember(dest => dest.SenderId,
                    opt => opt.Ignore());
            
            CreateMap<ChatDto, Chat>(MemberList.Destination)
                .ForPath(dest => dest.ChatType.Id,
                    opt => opt.MapFrom(src => src.ChatType.Id))
                .ForPath(dest => dest.ChatType.Alias,
                    opt => opt.MapFrom(src => src.ChatType.Alias))
                .ForMember(dest => dest.Users,
                    opt => opt.Ignore())
                // .ForMember(dest => dest.Users,
                //     opt => opt.MapFrom(src 
                //         => new List<User>
                //         {
                //             new User{ Id = src.SenderId }
                //         }))
                .ForMember(dest => dest.ChatTypeId,
                    opt => opt.Ignore());
        }
    }
}