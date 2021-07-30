using System;
using System.Threading;
using System.Threading.Tasks;
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
    public class UserService<TDbContext, TDto, TEntity> 
        : BaseService<TDbContext, TDto, TEntity, int>, 
            IUserService<TDto>
        where TDbContext : DbContext
        where TDto : UserDto
        where TEntity : UserBase
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="context"> DbContext. </param>
        /// <param name="mapper"> Mapper. </param>
        /// <param name="logger"> Logger. </param>
        public UserService(TDbContext context, 
            IMapper mapper, 
            ILogger<UserService<TDbContext, TDto, TEntity>> logger)
            : base(context, mapper, logger)
        {
        }

        /// <inheritdoc cref="IUserService{TDto,TKey}"/>
        public async Task Register(TDto dto, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start register user with Id={dto.Id}");
            var existingUserDto = await GetByIdAsync(dto.Id, cancellationToken);

            if (existingUserDto is null)
            {
                var newUserDto = await CreateAsync(dto, cancellationToken);
                return;
            }

            if (dto != existingUserDto)
                await UpdateAsync(dto, cancellationToken);
        }
    }
}