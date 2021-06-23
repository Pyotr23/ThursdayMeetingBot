namespace ThursdayMeetingBot.TelegramBot.Interfaces
{
    public interface IBotMessageService
    {
        /// <summary>
        ///     Processing a message
        /// </summary>
        /// <param name="updateMessage">New message</param>
        Task ProcessUpdateAsync(Update updateMessage);
    }
}