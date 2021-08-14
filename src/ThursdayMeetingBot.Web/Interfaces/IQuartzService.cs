using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Web.Models;

namespace ThursdayMeetingBot.Web.Interfaces
{
    /// <summary>
    ///     Hosted service using Quartz library.
    /// </summary>
    public interface IQuartzService
    {
        /// <summary>
        ///     Create job.
        /// </summary>
        /// <param name="info"> Information for creating job. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task. </returns>
        Task CreateJobAsync(NotificationInfo info, CancellationToken cancellationToken);
    }
}