using System;
using Microsoft.EntityFrameworkCore;
using ThursdayMeetingBot.Libraries.Core.Models.Entities;

namespace ThursdayMeetingBot.Libraries.Data.Models
{
    /// <summary>
    ///     User.
    /// </summary>
    [Index(nameof(TelegramChatId))]
    public record User : UserBase<int> 
    { }
}