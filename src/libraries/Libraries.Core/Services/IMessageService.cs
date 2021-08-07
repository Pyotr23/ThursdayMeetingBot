using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        ///     Write message to database.
        /// </summary>
        /// <param name="dto"> Message DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns></returns>
        Task<long> CreateAsync(MessageDto dto, CancellationToken cancellationToken);

        /// <summary>
        ///     Check that the message has not been received before 
        /// </summary>
        /// <param name="dto"> Message DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns></returns>
        Task<bool> IsNewAsync(MessageDto dto, CancellationToken cancellationToken);
    }
}