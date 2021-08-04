using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage chats.
    /// </summary>
    public interface IChatService : IService<ChatDto, long>
    {
        /// <summary>
        ///     Add if not exists or update if need.
        /// </summary>
        /// <param name="dto"> Chat DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task. </returns>
        Task RegisterAsync(ChatDto dto, CancellationToken cancellationToken);
    }
}