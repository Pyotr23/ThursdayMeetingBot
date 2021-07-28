using System;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage users.
    /// </summary>
    /// <typeparam name="TDto"> User DTO for add or update. </typeparam>
    /// <typeparam name="TKey"> Parameter with unique identifier of entry. </typeparam>
    public interface IUserService<TDto, TKey> 
        : IService<TDto, TKey> 
        where TDto : UserDto<TKey>
        where TKey : IEquatable<TKey>
    { }
}