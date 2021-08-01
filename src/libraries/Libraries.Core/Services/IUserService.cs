using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage users.
    /// </summary>
    public interface IUserService
        : IService<UserDto, int>
    {
        /// <summary>
        ///     Add if not exists or update if need.
        /// </summary>
        /// <param name="dto"> User DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task. </returns>
        Task RegisterAsync(UserDto dto, CancellationToken cancellationToken);
    }
}