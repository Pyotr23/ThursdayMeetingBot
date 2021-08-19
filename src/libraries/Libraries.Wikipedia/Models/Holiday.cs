namespace ThursdayMeetingBot.Libraries.Wikipedia.Models
{
    internal sealed record Holiday
    {
        internal string? Country { get; private set; }
        
        internal string Description { get; private set; }
        
        internal Holiday(string text)
        {
            
        }
    }
}