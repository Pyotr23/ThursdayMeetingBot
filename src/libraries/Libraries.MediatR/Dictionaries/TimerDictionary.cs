using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThursdayMeetingBot.Libraries.MediatR.Dictionaries
{
    /// <summary>
    ///     Dictionary of timers.
    /// </summary>
    public static class TimerDictionary
    {
        private static Dictionary<long, Timer> Dictionary { get; } = new();

        /// <summary>
        ///     Add to dictionary a new key-value pair.
        /// </summary>
        /// <param name="id"> Identificator-key. </param>
        /// <param name="timer"> Timer-value. </param>
        public static async Task AddAsync(long id, Timer timer)
        {
            await DeleteAsync(id);
            Dictionary.Add(id, timer);
        }

        /// <summary>
        ///     Stop and delete existing timer.
        /// </summary>
        /// <param name="id"> Timer identificator. </param>
        public static async Task DeleteAsync(long id)
        {
            if (Dictionary.ContainsKey(id))
            {
                var existingTimer = Dictionary[id];
                await existingTimer.DisposeAsync();
                Dictionary.Remove(id);
            }
        }
    }
}