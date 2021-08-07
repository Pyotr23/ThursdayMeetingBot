namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     Message DTO.
    /// </summary>
    public record MessageDto : DtoBase<long>
    {
        /// <summary>
        ///     Unique message identifier.
        /// </summary>
        public int MessageId { get; set; }
        
        /// <summary>
        ///     The actual UTF-8 text
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        ///     Chat identifier.
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        ///     Sender identifier.
        /// </summary>
        public int UserId { get; set; }
    }
}