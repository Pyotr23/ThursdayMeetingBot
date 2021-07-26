using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThursdayMeetingBot.Libraries.Core.Services
{
    /// <summary>
    ///     Base service for manage entries.
    /// </summary>
    /// <typeparam name="TDto"> Dto for add or update. </typeparam>
    /// <typeparam name="TEntity"> Entity for add or update. </typeparam>
    /// <typeparam name="TKey"> Parameter with unique identifier of entry. </typeparam>
    public interface IService<TDto, in TEntity, in TKey>
        where TDto : class
        where TEntity : class
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
        /// <param name="entityToAdd"> Model with information about new entry. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> New entry information. </returns>
        Task<TDto> CreateAsync(TEntity entityToAdd, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Update entry.
        /// </summary>
        /// <param name="entityToUpdate"> Model with information to update. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Update entry information. </returns>
        Task<bool> UpdateAsync(TEntity entityToUpdate, CancellationToken cancellationToken = default);
        
        /// <summary>
        ///     Delete entry.
        /// </summary>
        /// <param name="id"> Unique identifier. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> Method execution status. </returns>
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }
}