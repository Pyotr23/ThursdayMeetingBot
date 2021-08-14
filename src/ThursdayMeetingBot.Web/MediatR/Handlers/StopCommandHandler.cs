using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Services.Telegram;
using ThursdayMeetingBot.Libraries.Quartz.Interfaces;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Dictionaries;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.MediatR.Handlers
{
    /// <summary>
    ///     Command "/stop" handler.
    /// </summary>
    public class StopCommandHandler : IRequestHandler<StopCommand, Unit>
    {
        private readonly ILogger<StopCommandHandler> _logger;
        private readonly IQuartzService _quartzService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="quartzService"> Service for work with Quartz library. </param>
        public StopCommandHandler(ILogger<StopCommandHandler> logger,
            IQuartzService quartzService)
        {
            _logger = logger;
            _quartzService = quartzService;
        }

        /// <summary>
        ///     Handle command.
        /// </summary>
        /// <param name="request"> Command. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> A task with representation of the void type. </returns>
        public async Task<Unit> Handle(StopCommand request, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            _logger.LogInformation($"[{request.Id}] Handle of stop command");

            var result = await _quartzService.DeleteJobAsync(request.ChatId.ToString(), cancellationToken);

            return Unit.Value;
        }
    }
}