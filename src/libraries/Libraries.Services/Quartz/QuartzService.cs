using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using ThursdayMeetingBot.Libraries.Core.Models.Quartz;
using ThursdayMeetingBot.Libraries.Core.Services.Quartz;
using ThursdayMeetingBot.Libraries.Quartz.Jobs;

namespace ThursdayMeetingBot.Libraries.Services.Quartz
{
    /// <inheritdoc cref="IQuartzService"/>
    public class QuartzService : IQuartzService
    {
        private readonly ILogger<QuartzService> _logger; 
        private readonly IScheduler _scheduler;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="scheduler"> IScheduler instance. </param>
        public QuartzService(ILogger<QuartzService> logger, IScheduler scheduler)
        {
            _logger = logger;
            _scheduler = scheduler;
        }

        /// <inheritdoc cref="IQuartzService.ScheduleJobAsync"/>
        public async Task ScheduleJobAsync(long chatId, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start schedule job for chat {chatId}");
            
            
            var job = JobBuilder
                .Create<TextNotificationJob>()
                .WithIdentity(chatId.ToString())
                .Build();

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity(chatId.ToString())
                .StartNow()
                // .StartAt(new DateTimeOffset(dateTime))
                .WithSimpleSchedule(builder 
                    => builder
                        .WithIntervalInSeconds(30))
                .Build();

            await _scheduler.ScheduleJob(job, trigger, cancellationToken);
        }

        /// <inheritdoc cref="IQuartzService.DeleteJobAsync"/>
        public async Task<bool> DeleteJobAsync(string jobKeyName, CancellationToken cancellationToken)
        {
            var jobKey = new JobKey(jobKeyName);
            return await _scheduler.DeleteJob(jobKey, cancellationToken);
        }
    }
}