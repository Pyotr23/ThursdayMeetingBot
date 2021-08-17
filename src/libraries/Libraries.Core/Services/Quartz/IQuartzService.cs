using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.Quartz;

namespace ThursdayMeetingBot.Libraries.Core.Services.Quartz
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
        Task ScheduleJobAsync(NotificationInfo info, CancellationToken cancellationToken);

        /// <summary>
        ///     Delete job (stop notification).
        /// </summary>
        /// <param name="jobKeyName"> Name of job key. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Boolean result of deleting job. </returns>
        Task<bool> DeleteJobAsync(string jobKeyName, CancellationToken cancellationToken);
    }
}