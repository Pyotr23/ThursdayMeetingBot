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
        /// <inheritdoc />
        /// <param name="logger"> Logger. </param>
        public ChatService(TDbContext context,
            IMapper mapper,
            ILogger<ChatService<TDbContext>> logger)
        : base(context, mapper, logger)
        { }

        /// <inheritdoc />
        public Task RegisterAsync(ChatDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}