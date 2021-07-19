namespace ThursdayMeetingBot.Web.Configurations
{
    /// <summary>
    ///     Configuration for bot.
    /// </summary>
    public record BotConfiguration
    {
        /// <summary>
        ///     Access token.    
        /// </summary>
        public string AccessToken { get; init; }
    } 
}