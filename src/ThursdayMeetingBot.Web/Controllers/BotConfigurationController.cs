using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot.Exceptions;
using ThursdayMeetingBot.Libraries.Core.Models.Configurations;
using ThursdayMeetingBot.Web.Constants;
using ThursdayMeetingBot.Web.Models.WebHook;

#pragma warning disable 8620

namespace ThursdayMeetingBot.Web.Controllers
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
        ///     Constructor.
        /// </summary>
        /// <param name="httpClientFactory"> Factory for creating http clients. </param>
        /// <param name="botOptions"> Bot options. </param>
        /// <param name="logger"> ILogger instance. </param>
        public BotConfigurationController(IHttpClientFactory httpClientFactory, 
            IOptions<BotConfiguration> botOptions,
            ILogger<BotConfigurationController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _botConfiguration = botOptions.Value;
            _logger = logger; 
        }

        /// <summary>
        ///     Set web hook for current bot.
        /// </summary>
        /// <returns> Action result of setting webhook. </returns>
        [HttpPost]
        public async Task<ActionResult<WebHookSettingResult>> SetWebHook([FromBody] WebHookSettingInputModel input)
        {
            _logger.LogDebug($"Creating typed HttpClient for type {HttpClientConstant.Name}");
            
            var response = await GetWebHookSettingResponse(input.Uri);
            var result = await response
                .Content
                .ReadFromJsonAsync<WebHookSettingResult>();
            
            if (result == null)
            {
                throw new SerializationException(
                $"Exception while serialization error response from SetWebHook Telegram Api to type {nameof(WebHookSettingResult)}");
            }

            if (!response.IsSuccessStatusCode)
                throw new ApiRequestException(result.Description, result.ErrorCode);

            _logger.LogDebug("WebHook was set successfully");
            
            return result;
        }
        
        private async Task<HttpResponseMessage> GetWebHookSettingResponse(string uri)
        {
            var client = _httpClientFactory.CreateClient(HttpClientConstant.Name);
            var nameValueCollection = new[] { new KeyValuePair<string,string>(WebHookConstant.Url, uri) };
            var requestContent = new FormUrlEncodedContent(nameValueCollection);
            var requestUri = string.Format(WebHookConstant.RequestUriTemplate, _botConfiguration.AccessToken);
            return await client.PostAsync(requestUri, 
                requestContent, 
                CancellationToken.None);
        }
    }
}