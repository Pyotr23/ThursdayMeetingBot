using AutoMapper;

namespace ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    /// <summary>
    ///     Profile class for mapper user models.
    /// </summary>
    /// <typeparam name="TUser"> User. </typeparam>
    /// <typeparam name="TUserDto"> User DTO. </typeparam>
    public class UserMapperProfile<TUser, TUserDto> : Profile
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