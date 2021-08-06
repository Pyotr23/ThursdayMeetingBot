namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     DTO of chat type.
    /// </summary>
    public record ChatTypeDto : DtoBase<int>
    {
        /// <summary>
        ///     Alias.
        /// </summary>
        public string Alias { get; set; }
    }
}