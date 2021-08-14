using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram.Entity;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Handler for each incoming update.
    /// </summary>
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly ILogger<UpdateCommandHandler> _logger;
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        private readonly IChatTypeService _chatTypeService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        ///     Handler for writing update in database via user service.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="userService"> Service for managing users. </param>
        /// <param name="chatService"> Service for managing chats. </param>
        /// <param name="chatTypeService"> Service for managing chat types. </param>
        /// <param name="messageService"> Service for managing messages. </param>
        /// <param name="mapper"> Mapper. </param>
        /// <param name="mediator"> Mediator. </param>
        public UpdateCommandHandler(ILogger<UpdateCommandHandler> logger,
            IUserService userService,
            IChatService chatService,
            IChatTypeService chatTypeService,
            IMessageService messageService,
            IMapper mapper,
            IMediator mediator)
        {
            _logger = logger;
            _userService = userService;
            _chatService = chatService;
            _chatTypeService = chatTypeService;
            _messageService = messageService;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[{request.Id}] Update handler starts");
            
            var userDto = _mapper.Map<UserDto>(request.Sender);
            await _userService.RegisterAsync(userDto, cancellationToken);

            var chatTypeDto = _mapper.Map<ChatTypeDto>(request.Chat.Type);
            await _chatTypeService.RegisterAsync(chatTypeDto, cancellationToken); 

            var chatDto = _mapper.Map<ChatDto>(request.Update);
            await _chatService.RegisterAsync(chatDto, cancellationToken);

            var messageDto = _mapper.Map<MessageDto>(request.Update);
            if (!await _messageService.IsNewAsync(messageDto, cancellationToken))
            {
                _logger.LogInformation($"[{request.Id}] Repeat command");
                return Unit.Value;
            }
            await _messageService.CreateAsync(messageDto, cancellationToken);
            
            await _mediator.Send(new MessageCommand(request.Update), cancellationToken);
            return Unit.Value;
        }
    }
}