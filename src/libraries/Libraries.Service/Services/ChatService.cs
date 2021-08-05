using System;
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
        /// <param name="logger"> Logger. </param>
        public ChatService(TDbContext context,
            IMapper mapper,
            ILogger<ChatService<TDbContext>> logger)
            : base(context, mapper, logger)
        {
            _users = DbContext.Set<User>();
            _chatTypes = DbContext.Set<ChatType>();
        }

        /// <inheritdoc />
        public Task RegisterAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<long> CreateAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Creating new chat");
            
            var chat = Mapper.Map<Chat>(dto);
            chat.ChatType = await _chatTypes.FindAsync(dto.ChatType.Id);
            var user = await _users.FindAsync(dto.SenderId);
            chat.Users.Add(user);

            await DbSet
                .AddAsync(chat, cancellationToken)
                .ConfigureAwait(false);
                
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            if (commitStatus.Equals(0))
                throw new DbUpdateException("Some error occurred while creating new user");

            return chat.Id;
        }

        public async Task UpdateAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}