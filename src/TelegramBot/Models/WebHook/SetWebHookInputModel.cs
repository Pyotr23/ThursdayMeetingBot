using System.ComponentModel.DataAnnotations;

namespace ThursdayMeetingBot.TelegramBot.Models.WebHook
{
    /// <summary>
    ///     Input model for set web hook action
    /// </summary>
    internal record SetWebHookInputModel
    {
        /// <summary>
        ///     Which address will be set as webhook.
        /// </summary>
        [Required]
        [Url]
        internal string WebHookUri { get; init; }
    }
}