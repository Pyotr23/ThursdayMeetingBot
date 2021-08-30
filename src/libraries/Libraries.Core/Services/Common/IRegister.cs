using System;
using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Libraries.Core.Services.Common
{
    /// <summary>
    ///     Ability to register an entity.
    /// </summary>
    /// <typeparam name="TDto"> DTO. </typeparam>
    /// <typeparam name="TKey"> Unique identificator. </typeparam>
    public interface IRegister<in TDto, TKey> 
    where TDto : DtoBase<TKey>
    where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Create or update an entity if required
        /// </summary>
        /// <param name="dto"> DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns></returns>
        Task RegisterAsync(TDto dto, CancellationToken cancellationToken);

        /// <summary>
        ///     Create new entity.
        /// </summary>
        /// <param name="dto"> DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Unique identificator of new entity. </returns>
        Task<TKey> CreateAsync(TDto dto, CancellationToken cancellationToken);

        /// <summary>
        ///     Update entity.
        /// </summary>
        /// <param name="dto"> DTO. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        Task UpdateAsync(TDto dto, CancellationToken cancellationToken);
    }
}