using System;
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
    /// <typeparam name="TKey"> Unique key. </typeparam>
    public class UserMapperProfile<TUser, TUserDto, TKey> : Profile
        where TUser : UserBase<TKey>
        where TUserDto : UserDto<TKey>
        where TKey : IEquatable<TKey>
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