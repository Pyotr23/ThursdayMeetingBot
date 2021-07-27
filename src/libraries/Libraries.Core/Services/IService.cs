using System;
using System.Threading;
using System.Threading.Tasks;
using ThursdayMeetingBot.Libraries.Core.Models.Entities.Base;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Base service for manage entries.
    /// </summary>
    /// <typeparam name="TDto"> Dto for add or update. </typeparam>
    /// <typeparam name="TEntity"> Entity for add or update. </typeparam>
    /// <typeparam name="TKey"> Parameter with unique identifier of entry. </typeparam>
    public interface IService<TDto, in TEntity, TKey>
        where TDto : class
        where TEntity : AggregatedEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Get one entry.
        /// </summary>
        /// <param name="id"> Unique identifier. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> One entry result. </returns>
        Task<TDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Create new entry.
        /// </summary>
        /// <param name="dtoToAdd"> DTO with information about new entry. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> New entry information. </returns>
        Task<TKey> CreateAsync(TDto dtoToAdd, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Update entry.
        /// </summary>
        /// <param name="dtoToUpdate"> DTO with information to update. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Update entry information. </returns>
        Task<bool> UpdateAsync(TDto dtoToUpdate, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Delete entry.
        /// </summary>
        /// <param name="id"> Unique identifier. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Method execution status. </returns>
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }
}