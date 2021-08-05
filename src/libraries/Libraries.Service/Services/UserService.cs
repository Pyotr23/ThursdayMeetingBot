using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;
using ThursdayMeetingBot.Libraries.Data.Models;
using ThursdayMeetingBot.Libraries.Service.Services.Common;

namespace ThursdayMeetingBot.Libraries.Service.Services
{
    /// <inheritdoc cref="IUserService"/>
    public class UserService<TDbContext> : BaseService<TDbContext, User, int>, IUserService
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
        { }

        /// <inheritdoc />
        public async Task RegisterAsync(UserDto dto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Start register user with Id={dto.Id}");

            var dbUser = await DbSet.FindAsync(dto.Id);

            if (dbUser is null)
            {
                await CreateAsync(dto, cancellationToken);
                return;
            }

            var dbUserDto = Mapper.Map<UserDto>(dbUser);
            
            if (dto != dbUserDto)
                await UpdateAsync(dto, cancellationToken);
        }

        
        /// <inheritdoc />
        /// <exception cref="DbUpdateException"> Exception when saving failed. </exception>
        public async Task<int> CreateAsync(UserDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Creating new user");
            
            var user = Mapper.Map<User>(dto);
                
             await DbSet
                .AddAsync(user, cancellationToken)
                .ConfigureAwait(false);
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException("Some error occurred while creating new user");

            return user.Id;
        }

        /// <inheritdoc />
        /// <exception cref="DbUpdateException"> Exception when saving failed. </exception>
        public async Task UpdateAsync(UserDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Updating user");
                
            var user = Mapper.Map<User>(dto);
            
            DbContext
                .ChangeTracker
                .Clear();
                
            DbSet
                .Update(user)
                .Property(u => u.CreatedDate)
                .IsModified = false;
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException($"Some error occurred white updating user with Id={user.Id}");
        }
    }
}