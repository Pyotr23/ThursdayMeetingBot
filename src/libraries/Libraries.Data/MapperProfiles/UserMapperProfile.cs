using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    /// <summary>
    ///     Profile class for mapper user models.
    /// </summary>
    public class UserMapperProfile : Profile
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public UserMapperProfile()
        {
            CreateMap<User, UserDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}