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
    /// <inheritdoc cref="IChatService"/>
    /// <inheritdoc cref="BaseService{TDbContext}"/>
    public class ChatService<TDbContext> : BaseService<TDbContext>, IChatService
    where TDbContext : DbContext
    {
        private readonly ILogger<ChatService<TDbContext>> _logger;
        private readonly DbSet<Chat> _chats;
        private readonly DbSet<ChatType> _chatTypes;
        
        /// <inheritdoc />
        /// <param name="logger"> Logger. </param>
        public ChatService(TDbContext context,
            IMapper mapper,
            ILogger<ChatService<TDbContext>> logger)
        : base(context, mapper)
        {
            _logger = logger;
            _chats = DbContext.Set<Chat>();
            _chatTypes = DbContext.Set<ChatType>();
        }
            
        
        public async Task<ChatDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start getting chat with Id={id}");
            var entity = await _chats
                .Include(c => c.ChatType)
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
                .ConfigureAwait(false);
            
            if (entity is null)
            {
                _logger.LogDebug($"No chat with Id={id}");
                return null;
            }
                
            var result = Mapper.Map<ChatDto>(entity);
            return result;
        }

        public async Task<long> CreateAsync(ChatDto dtoToAdd, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("Start creating new chat");
            var entity = Mapper.Map<Chat>(dtoToAdd);

            var chatTypeId = await _chatTypes
                .FirstOrDefaultAsync(ct => ct.Alias == dtoToAdd.ChatType.Alias, cancellationToken)
                .ConfigureAwait(false);

            entity.ChatType = null;
            entity.ChatTypeId = chatTypeId.Id;
            
            await _chats
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);
            
            _logger.LogDebug("Creating new chat save changes");
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            
            if (commitStatus.Equals(0))
                throw new DbUpdateException("Some error occurred white creating new chat");

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ChatDto dtoToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}