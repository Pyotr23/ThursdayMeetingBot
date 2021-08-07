using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///      Handler for processing messages
    /// </summary>
    public class MessageCommandHandler : IRequestHandler<MessageCommand>
    {
        private readonly ILogger<MessageCommandHandler> _logger;
        private readonly IMediator _mediator;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="mediator"> Mediator. </param>
        public MessageCommandHandler(ILogger<MessageCommandHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(MessageCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[{request.Id}] Start message handler");

            var update = request.Update;
            BaseBotCommand<Unit> command;
            
            switch (request.Message.Text)
            {
                case BotCommand.Start:
                    command = new StartCommand(update);
                    break;
                case BotCommand.Stop:
                    command = new StopCommand(update);
                    break;
                default:
                    _logger.LogWarning($"[{request.Id}] Unknown bot command \"{request.Message.Text}\"");
                    return Unit.Value;
            }

            await _mediator.Send(command, cancellationToken);
            return Unit.Value;
        }
    }
}