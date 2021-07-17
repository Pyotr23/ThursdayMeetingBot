using System.ComponentModel.DataAnnotations;

namespace ThursdayMeetingBot.TelegramBot.Models.WebHook
{
    /// <summary>
    ///     Input model for set web hook action
    /// </summary>
    public record WebHookSettingInputModel
    {
        /// <summary>
        ///     Which address will be set as webhook.
        /// </summary>
        [Required]
        [Url]
        public string Uri { get; init; }
    }
}