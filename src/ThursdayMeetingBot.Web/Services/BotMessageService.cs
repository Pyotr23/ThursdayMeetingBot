using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Interfaces;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.Services
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
                BaseBotCommand<Unit> command;
                switch (message.Text)
                {
                    case BotCommand.Start:
                        command = new StartCommand(update);
                        break;
                    case BotCommand.Stop:
                        command = new StopCommand(update); 
                        break;
                    default:
                        _logger.LogWarning("Unknown bot command \"{0}\"", message.Text);
                        return;
                }
                await _mediator.Send(command);
            }
        }
    }
}