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
    /// <inheritdoc cref="IChatTypeService"/>
    public class ChatTypeService<TDbContext> : BaseService<TDbContext, ChatType, int>, IChatTypeService
        where TDbContext : DbContext
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="context"> DbContext. </param>
        /// <param name="mapper"> Mapper. </param>
        /// <param name="logger"> Logger. </param>
        public ChatTypeService(TDbContext context,
            IMapper mapper,
            ILogger<ChatTypeService<TDbContext>> logger)
            : base(context, mapper, logger)
        { }

        /// <inheritdoc />
        public async Task RegisterAsync(ChatTypeDto dto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Start register chat type with Id={dto.Id}");

            var dbChatType = await DbSet.FindAsync(new object[] { dto.Id }, cancellationToken);

            if (dbChatType is null)
                await CreateAsync(dto, cancellationToken);
        }
        
        /// <inheritdoc />
        /// <exception cref="DbUpdateException"> Exception when saving failed. </exception>
        public async Task<int> CreateAsync(ChatTypeDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Creating new chat type");
            
            var chatType = Mapper.Map<ChatType>(dto);

            await DbSet
                .AddAsync(chatType, cancellationToken)
                .ConfigureAwait(false);
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException("Some error occurred while creating new chat type");

            return chatType.Id;
        }

        /// <inheritdoc />
        /// <exception cref="DbUpdateException"> Exception when saving failed. </exception>
        public async Task UpdateAsync(ChatTypeDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Updating chat type");
                
            var chatTypeDto = Mapper.Map<ChatType>(dto);
            
            DbContext
                .ChangeTracker
                .Clear();
                
            DbSet
                .Update(chatTypeDto)
                .Property(u => u.CreatedDate)
                .IsModified = false;
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException(
                    $"Some error occurred white updating chat type with Id={chatTypeDto.Id}");
        }
    }
}