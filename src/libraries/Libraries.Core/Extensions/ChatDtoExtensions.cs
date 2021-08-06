using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Extensions
{
    /// <summary>
    ///     Extensions fot chat DTO.
    /// </summary>
    public static class ChatDtoExtensions
    {
        /// <summary>
        ///     Compare two user DTO.
        /// </summary>
        /// <param name="firstDto"> First user DTO for comparing. </param>
        /// <param name="secondDto"> Second user DTO for comparing. </param>
        /// <returns> Bool result. </returns>
        public static bool IsEqual(this ChatDto firstDto, ChatDto secondDto)
        {
            return firstDto.Username == secondDto.Username
                   && firstDto.FirstName == secondDto.FirstName
                   && firstDto.LastName == secondDto.LastName
                   && firstDto.Title == secondDto.Title;
        }
    }
}