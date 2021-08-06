using System.Linq;
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
    public class ChatService<TDbContext> : BaseService<TDbContext, Chat, long>, IChatService
    where TDbContext : DbContext
    {
        private readonly DbSet<User> _users;
        private readonly DbSet<ChatType> _chatTypes;
        
        /// <inheritdoc />
        public ChatService(TDbContext context,
            IMapper mapper,
            ILogger<ChatService<TDbContext>> logger)
            : base(context, mapper, logger)
        {
            _users = DbContext.Set<User>();
            _chatTypes = DbContext.Set<ChatType>();
        }

        /// <inheritdoc />
        public async Task RegisterAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Start register user with Id={dto.Id}");

            var dbChat = await DbSet
                .Include(c => c.Users)
                .FirstOrDefaultAsync(c => c.Id == dto.Id, cancellationToken);

            if (dbChat is null)
            {
                await CreateAsync(dto, cancellationToken);
                return;
            }
            
            if (!(dto.Title == dbChat.Title
                  && dto.Username == dbChat.Username
                  && dto.FirstName == dbChat.FirstName
                  && dto.LastName == dbChat.LastName))
                await UpdateAsync(dto, cancellationToken);

            if (!dbChat.Users.Select(u => u.Id).Contains(dto.SenderId))
                await AddUserAsync(dto, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<long> CreateAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Creating new chat");
            
            var chat = Mapper.Map<Chat>(dto);
            chat.ChatType = await _chatTypes.FindAsync(dto.ChatType.Id, cancellationToken);
            var user = await _users.FindAsync(dto.SenderId, cancellationToken);
            chat.Users.Add(user);

            await DbSet
                .AddAsync(chat, cancellationToken)
                .ConfigureAwait(false);
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException("Some error occurred while creating new chat");

            return chat.Id;
        }

        public async Task UpdateAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Updating chat");
                
            var chat = Mapper.Map<Chat>(dto);

            DbContext
                .ChangeTracker
                .Clear();

            DbSet
                .Update(chat)
                .Property(u => u.CreatedDate)
                .IsModified = false;
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException($"Some error occurred while updating chat with Id={chat.Id}");
        }

        private async Task AddUserAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Adding user to chat");
                
            var chat = Mapper.Map<Chat>(dto);
            var user = await _users.FindAsync(dto.SenderId, cancellationToken);
            chat.Users.Add(user);

            DbContext
                .ChangeTracker
                .Clear();

            DbSet
                .Update(chat)
                .Property(u => u.CreatedDate)
                .IsModified = false;
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException($"Some error occurred while adding user to chat with Id={chat.Id}");
        }
    }
}