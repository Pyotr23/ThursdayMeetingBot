using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage chats.
    /// </summary>
    public interface IChatService : IService<ChatDto, long>
    { }
}