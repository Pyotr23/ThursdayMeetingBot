using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using ThursdayMeetingBot.TelegramBot.Configurations;

namespace ThursdayMeetingBot.TelegramBot.Controllers
{
    /// <summary>
    ///     Controller for manage bot configuration.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
    public class BotConfigurationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BotConfiguration _botConfiguration;
        private readonly ILogger<BotConfigurationController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory">Factory for creating http clients</param>
        /// <param name="botOptions">Bot options</param>
        /// <param name="logger">ILogger instance</param>
        public BotConfigurationController(IHttpClientFactory httpClientFactory, 
            IOptions<BotConfiguration> botOptions,
            ILogger<BotConfigurationController> logger = null)
        {
            _httpClientFactory = httpClientFactory;
            _botConfiguration = botOptions.Value;
            _logger = logger ?? NullLogger<BotConfigurationController>.Instance;
        }

        /// <summary>
        /// Set web hook for current bot
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SetWebHookApiResult>> SetWebHook([FromBody] SetWebHookInputModel value)
        {
            _logger.LogDebug($"Creating typed HttpClient for type {TypedHttpClients.TelegramApi}");
            var client = _httpClientFactory.CreateClient(TypedHttpClients.TelegramApi);
            var requestContent = new FormUrlEncodedContent(new []
            {
                new KeyValuePair<string, string>("url", value.WebHookUri) 
            });
            var response = await client.PostAsync($"/bot{_botConfiguration.AccessToken}/setWebhook", requestContent, CancellationToken.None);
            if (!response.IsSuccessStatusCode)
            {
                var responseWithError = await response.Content.ReadFromJsonAsync<SetWebHookApiResult>();
                if (responseWithError == null)
                    throw new SerializationException(
                        $"Exception while serialization error response from SetWebHook Telegram Api to type {nameof(SetWebHookApiResult)}");
                throw new ApiRequestException(responseWithError.Description, responseWithError.Error_code);
            }
            _logger.LogDebug("WebHook was set successfully");
            var responseSuccess = await response.Content.ReadFromJsonAsync<SetWebHookApiResult>();
            if (responseSuccess == null)
                throw new SerializationException(
                    $"Exception while serialization success response from SetWebHook Telegram Api to type {nameof(SetWebHookApiResult)}");
            return responseSuccess;
        }
    }
}