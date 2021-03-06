using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using ThursdayMeetingBot.Web.Extensions;
using ThursdayMeetingBot.Web.MediatR.Commands;

namespace ThursdayMeetingBot.Web.Controllers
{
    /// <summary>
    ///     Update controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="logger"> Logger. </param>
        /// <param name="mediator"> Mediator. </param>
        public UpdateController(ILogger<UpdateController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        ///     Post method for receive messages from Bot (Using webhook).
        /// </summary>
        /// <param name="update"> New update from bot. </param>
        /// <returns> Ok Action or error. </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            _logger.LogInformation($"[{update.Id}] Start to handle update: {update.GetInfo()}");

            if (!update.IsBotCommand())
            {
                _logger.LogInformation($"[{update.Id}] Update is not bot command");
                return Ok();
            }
            
            try
            {
                await _mediator.Send(new UpdateCommand(update));
                _logger.LogInformation($"[{update.Id}] Update processed");
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{update.Id}] Error when handle update{Environment.NewLine}{ex}");
            }
            
            return Ok();
        }
    }
}