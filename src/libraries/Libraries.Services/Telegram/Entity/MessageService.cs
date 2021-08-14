using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;
using ThursdayMeetingBot.Libraries.Data.Models;
using ThursdayMeetingBot.Libraries.Services.Common;

namespace ThursdayMeetingBot.Libraries.Services.Telegram.Entity
{
    /// <inheritdoc cref="IMessageService"/>
    public class MessageService<TDbContext> : BaseService<TDbContext, Message, long>, IMessageService
    where TDbContext : DbContext
    {
        private readonly DbSet<Chat> _chats;
        private readonly DbSet<User> _users;
        
        /// <inheritdoc />
        public MessageService(TDbContext context,
            IMapper mapper,
            ILogger<MessageService<TDbContext>> logger)
            : base(context, mapper, logger)
        {
            _chats = DbContext.Set<Chat>();
            _users = DbContext.Set<User>();
        }

        /// <inheritdoc />
        public async Task<long> CreateAsync(MessageDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Write message to database");
            
            var message = Mapper.Map<Message>(dto);
            message.Chat = await _chats.FindAsync(new object[] { dto.ChatId }, cancellationToken);
            message.User = await _users.FindAsync(new object[] { dto.UserId }, cancellationToken);

            await DbSet
                .AddAsync(message, cancellationToken)
                .ConfigureAwait(false);
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException("Some error occurred while creating new message");

            return message.Id;
        }

        /// <inheritdoc />
        public async Task<bool> IsNewAsync(MessageDto dto, CancellationToken cancellationToken)
        {
            var dbMessage = await DbSet
                .Where(m => m.ChatId == dto.ChatId)
                .OrderByDescending(m => m.CreatedDate)
                .FirstOrDefaultAsync(cancellationToken);
            return dbMessage is null 
                   || dbMessage.Text != dto.Text;
        }
    }
}