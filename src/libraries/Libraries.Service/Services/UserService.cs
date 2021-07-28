using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Models.Entities;
using ThursdayMeetingBot.Libraries.Core.Services;

namespace ThursdayMeetingBot.Libraries.Service.Services
{
    /// <inheritdoc cref="IUserService{TDto,TKey}" />
    /// <typeparam name="TDbContext"> DbContext. </typeparam>
    /// <typeparam name="TEntity"> User class from database. </typeparam>
    public class UserService<TDbContext, TDto, TEntity, TKey> 
        : BaseService<TDbContext, TDto, TEntity, TKey>, 
            IUserService<TDto, TKey>
        where TDbContext : DbContext
        where TDto : UserDto<TKey>
        where TEntity : UserBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="context"> DbContext. </param>
        /// <param name="mapper"> Mapper. </param>
        /// <param name="logger"> Logger. </param>
        public UserService(TDbContext context, 
            IMapper mapper, 
            ILogger<UserService<TDbContext, TDto, TEntity, TKey>> logger)
            : base(context, mapper, logger)
        {
        }
    }
}