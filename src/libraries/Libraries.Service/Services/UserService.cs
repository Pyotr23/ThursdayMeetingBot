using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Extensions;
using ThursdayMeetingBot.Libraries.Core.Models.BaseEntities;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;

namespace ThursdayMeetingBot.Libraries.Service.Services
{
    /// <inheritdoc cref="IUserService{TDto}" />
    /// <typeparam name="TDbContext"> DbContext. </typeparam>
    /// <typeparam name="TEntity"> User class from database. </typeparam>
    /// <typeparam name="TDto"> User DTO. </typeparam>
    public class UserService<TDbContext, TDto, TEntity> 
        : BaseService<TDbContext, TDto, TEntity, int>, 
            IUserService<TDto>
        where TDbContext : DbContext
        where TDto : UserDto
        where TEntity : UserBase<int>
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

        /// <inheritdoc cref="IUserService{TDto}"/>
        public async Task RegisterAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start register user with Id={dto.Id}");
            var existingUserDto = await GetByIdAsync(dto.Id, cancellationToken);

            if (existingUserDto is null)
            {
                await CreateAsync(dto, cancellationToken);
                return;
            }

            if (!dto.IsEqual(existingUserDto))
                await UpdateAsync(dto, cancellationToken);
        }
    }
}