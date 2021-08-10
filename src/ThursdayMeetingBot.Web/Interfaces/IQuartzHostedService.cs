using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quartz;
using ThursdayMeetingBot.Web.Models;

namespace ThursdayMeetingBot.Web.Interfaces
{
    /// <summary>
    ///     Hosted service using Quartz library.
    /// </summary>
    public interface IQuartzHostedService
    {
        /// <summary>
        ///     Get detail of job instance.
        /// </summary>
        /// <param name="jobName"> Job name. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task with job detail example. </returns>
        Task<IJobDetail> GetJobDetailAsync(string jobName, CancellationToken cancellationToken);
        
        /// <summary>
        ///     Create job.
        /// </summary>
        /// <param name="info"> Information for creating job. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task. </returns>
        Task CreateJobAsync(NotificationInfo info, CancellationToken cancellationToken);

        Task StartAsync(CancellationToken cancellationToken);
    }
}