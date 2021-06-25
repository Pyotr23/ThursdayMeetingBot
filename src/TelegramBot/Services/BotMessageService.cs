using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ThursdayMeetingBot.TelegramBot.Constants;
using ThursdayMeetingBot.TelegramBot.Interfaces;
using ThursdayMeetingBot.TelegramBot.MediatR.Commands;

namespace ThursdayMeetingBot.TelegramBot.Services
{
    /// <inheritdoc />
    public class BotMessageService : IBotMessageService
    {
        private readonly ILogger<BotMessageService> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="mediator"> Mediator. </param>
        public BotMessageService(ILogger<BotMessageService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        /// <inheritdoc />
        public async Task ProcessAsync(Update update)
        {
            _logger.LogDebug("Received message with text \"{0}\".", update.Message.Text);
            var message = update.Message;
            _logger.LogInformation("Received message from {0}", message.Chat.Id);
            var firstEntityType = message
                .Entities
                .FirstOrDefault()?
                .Type; 
            if (firstEntityType == MessageEntityType.BotCommand)
            {
                switch (message.Text)
                {
                    case BotCommand.Start:
                        await _mediator.Send(new StartCommand(message));
                        break;
                    default:
                        _logger.LogInformation("Unknown bot command \"{0}\"", message.Text);
                        break;
                }
            }
        }
    }
}