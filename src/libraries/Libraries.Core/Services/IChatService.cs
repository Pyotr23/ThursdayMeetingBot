using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services.Common;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage chats.
    /// </summary>
    public interface IChatService : IRegister<ChatDto, long>
    { }
}