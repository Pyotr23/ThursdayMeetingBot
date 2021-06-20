﻿namespace ThursdayMeetingBot.TelegramBot.Models.WebHook
{
    /// <summary>
    ///     Set web hook api result model.
    /// </summary>
    /// <param name="ErrorCode"> Error code. </param>
    /// <param name="Description"> Description message. </param>
    public record SetWebHookResult(int ErrorCode, string Description);
}