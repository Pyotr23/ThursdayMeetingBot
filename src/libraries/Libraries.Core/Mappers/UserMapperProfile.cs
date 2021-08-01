using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.BaseEntities;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Mappers
{
    /// <summary>
    ///     Profile class for mapper user models.
    /// </summary>
    /// <typeparam name="TUser"> User. </typeparam>
    /// <typeparam name="TUserDto"> User DTO. </typeparam>
    public class UserMapperProfile<TUser, TUserDto> : Profile
    where TUser : UserBase<int>
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