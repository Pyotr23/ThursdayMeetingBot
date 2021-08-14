using System.Threading;
using System.Threading.Tasks;
using Quartz;
using ThursdayMeetingBot.Libraries.Quartz.Interfaces;
using ThursdayMeetingBot.Libraries.Quartz.Jobs;
using ThursdayMeetingBot.Libraries.Quartz.Models;

namespace ThursdayMeetingBot.Libraries.Services.Quartz
{
    /// <inheritdoc cref="IQuartzService"/>
    public class QuartzService : IQuartzService
    {
        private readonly IScheduler _scheduler;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="scheduler"> IScheduler instance. </param>
        public QuartzService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        /// <inheritdoc cref="IQuartzService.CreateJobAsync"/>
        public async Task CreateJobAsync(NotificationInfo info, CancellationToken cancellationToken)
        {
            var (chatId, notificationMessage) = info;
            
            var job = JobBuilder
                .Create<TextNotificationJob>()
                .WithIdentity(chatId.ToString())
                .UsingJobData(nameof(TextNotificationJob.NotificationMessage), notificationMessage)
                .Build();

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity(chatId.ToString())
                .StartNow()
                // .StartAt(new DateTimeOffset(dateTime))
                .WithSimpleSchedule(builder 
                    => builder
                        .WithIntervalInSeconds(60)
                        .RepeatForever())
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