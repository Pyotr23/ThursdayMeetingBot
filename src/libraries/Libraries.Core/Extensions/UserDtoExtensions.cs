using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Extensions
{
    /// <summary>
    ///     Extensions fot user DTO.
    /// </summary>
    public static class UserDtoExtensions
    {
        /// <summary>
        ///     Compare two user DTO.
        /// </summary>
        /// <param name="firstDto"> First user DTO for comparing. </param>
        /// <param name="secondDto"> Second user DTO for comparing. </param>
        /// <returns> Bool result. </returns>
        public static bool IsEqual(this UserDto firstDto, UserDto secondDto)
        {
            return firstDto.Username == secondDto.Username
                   && firstDto.FirstName == secondDto.FirstName
                   && firstDto.LastName == secondDto.LastName;
        }
    }
}