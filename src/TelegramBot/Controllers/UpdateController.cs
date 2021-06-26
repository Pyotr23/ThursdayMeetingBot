﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using ThursdayMeetingBot.TelegramBot.Interfaces;

namespace ThursdayMeetingBot.TelegramBot.Controllers
{
    /// <summary>
    ///     Update controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IBotMessageService _botMessageService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="botMessageService"> Service for manage bot messages. </param>
        public UpdateController(IBotMessageService botMessageService, IBotService botService)
        {
            _botMessageService = botMessageService;
        }

        /// <summary>
        ///     Post method for receive messages from Bot (Using webhook).
        /// </summary>
        /// <param name="update"> New update from bot. </param>
        /// <returns> Ok Action or error. </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _botMessageService.ProcessAsync(update);
            return Ok();
        }
    }
}