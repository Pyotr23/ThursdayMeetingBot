namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    public record MessageDto : DtoBase<long>
    {
        public int MessageId { get; set; }
        
        public string Text { get; set; }
        
        public long ChatId { get; set; }

        public int UserId { get; set; }
    }
}