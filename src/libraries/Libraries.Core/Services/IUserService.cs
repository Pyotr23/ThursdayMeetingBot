using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Service for manage users.
    /// </summary>
    /// <typeparam name="TDto"> User DTO for add or update. </typeparam>
    public interface IUserService<TDto>
        : IService<TDto, int>
        where TDto : UserDto
    {
        /// <summary>
        ///     Add if not exists or update if need.
        /// </summary>
        /// <param name="dto"> User DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Task. </returns>
        Task Register(TDto dto, CancellationToken cancellationToken);
    }
}