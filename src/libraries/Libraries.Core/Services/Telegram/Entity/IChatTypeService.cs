using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services.Common;

namespace ThursdayMeetingBot.Libraries.Core.Services.Telegram.Entity
{
    /// <summary>
    ///     Service for manage types of chats.
    /// </summary>
    public interface IChatTypeService : IRegister<ChatTypeDto, int>
    { }
}