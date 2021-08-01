using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Extensions;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Service.Services
{
    /// <typeparam name="TDbContext"> DbContext. </typeparam>
    public class UserService<TDbContext> 
        : BaseService<TDbContext, UserDto, User, int>, IUserService
        where TDbContext : DbContext
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="context"> DbContext. </param>
        /// <param name="mapper"> Mapper. </param>
        /// <param name="logger"> Logger. </param>
        public UserService(TDbContext context, 
            IMapper mapper, 
            ILogger<UserService<TDbContext>> logger)
            : base(context, mapper, logger)
        {
        }

        /// <inheritdoc />
        public async Task RegisterAsync(UserDto dto, CancellationToken cancellationToken = default)
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