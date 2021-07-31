using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Handler for each incoming update.
    /// </summary>
    public class UpdateCommandHandler<TUserDto> : IRequestHandler<UpdateCommand, Unit>
    where TUserDto : UserDto
    {
        private readonly ILogger<UpdateCommandHandler<TUserDto>> _logger;
        private readonly IUserService<TUserDto> _userService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        ///     Handler for writing update in database via user service.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="userService"> Service for managing users. </param>
        /// <param name="mapper"> Mapper. </param>
        /// <param name="mediator"> Mediator. </param>
        public UpdateCommandHandler(ILogger<UpdateCommandHandler<TUserDto>> logger,
            IUserService<TUserDto> userService,
            IMapper mapper,
            IMediator mediator)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[{request.Id}] Update handler starts");
            var userDto = _mapper.Map<TUserDto>(request.Sender);
            await _userService.RegisterAsync(userDto, cancellationToken);
            await _mediator.Send(new MessageCommand(request.Update), cancellationToken);
            return Unit.Value;
        }
    }
}