using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Models.Entities;

namespace ThursdayMeetingBot.Libraries.Core.Mappers
{
    /// <summary>
    ///     Profile class for mapper user models.
    /// </summary>
    /// <typeparam name="TUser"> User. </typeparam>
    /// <typeparam name="TUserDto"> User DTO. </typeparam>
    public class UserMapperProfile<TUser, TUserDto> : Profile
        where TUser : UserBase
        where TUserDto : UserDto
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public UserMapperProfile()
        {
            CreateMap<TUser, TUserDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}