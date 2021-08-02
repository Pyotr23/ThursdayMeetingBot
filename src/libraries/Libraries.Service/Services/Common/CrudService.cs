using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.Common;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Core.Services;

namespace ThursdayMeetingBot.Libraries.Service.Services.Common
{
    /// <summary>
    ///     Service with simple CRUD operations.
    /// </summary>
    /// <typeparam name="TDbContext"> DbContext. </typeparam>
    /// <typeparam name="TDto"> DTO model. </typeparam>
    /// <typeparam name="TEntity"> The entity with which the basic operations will be performed on the table. </typeparam>
    /// <typeparam name="TKey"> Type of entry unique identifier. </typeparam>
    public abstract class CrudService<TDbContext, TDto, TEntity,TKey> 
        : BaseService<TDbContext>, IService<TDto,TKey>
    where TDbContext : DbContext
    where TDto : DtoBase<TKey>
    where TEntity : AggregatedEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        private readonly string _typeName = typeof(TEntity).Name;
        
        private readonly DbSet<TEntity> _dbSet;
        protected readonly ILogger<CrudService<TDbContext, TDto, TEntity, TKey>> _logger;

        protected CrudService(TDbContext context, 
            IMapper mapper, 
            ILogger<CrudService<TDbContext, TDto, TEntity, TKey>> logger)
            : base(context, mapper)
        {
            _dbSet = DbContext.Set<TEntity>();
            _logger = logger;
        }
        
        /// <inheritdoc />
        public async Task<TDto?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start getting {_typeName} with Id={id}");
            var entity = await _dbSet
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
                .ConfigureAwait(false);
            
            if (entity is null)
            {
                _logger.LogDebug($"No {_typeName} with Id={id}");
                return null;
            }
                
            var result = Mapper.Map<TDto>(entity);
            return result;
        }

        /// <inheritdoc />
        public async Task<TKey> CreateAsync(TDto dtoToAdd, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start creating new {_typeName}");
            var entity = Mapper.Map<TEntity>(dtoToAdd);
            await _dbSet
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);
            
            _logger.LogDebug($"Creating new {_typeName} save changes");
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            
            if (commitStatus.Equals(0))
                throw new DbUpdateException($"Some error occurred white creating new {_typeName}");

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<bool> UpdateAsync(TDto dtoToUpdate, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start updating {_typeName}");

            DbContext
                .ChangeTracker
                .Clear();
            
            var entity = Mapper.Map<TEntity>(dtoToUpdate);

            _dbSet
                .Update(entity)
                .Property(x => x.CreatedDate)
                .IsModified = false;
            
            _logger.LogDebug($"Updating {_typeName} save changes");
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            
            if (commitStatus.Equals(0))
                throw new DbUpdateException($"Some error occurred while updating {_typeName} " +
                                            $"with Id={entity.Id}");
            
            return commitStatus > 0;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Start deleting {_typeName} with Id={id}");
            var entity = await _dbSet
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
                .ConfigureAwait(false);
            
            if (entity is null)
                return true;
            
            _dbSet.Remove(entity);
            
            _logger.LogDebug($"Delete {_typeName} save changes");
            var commitStatus = await DbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            
            if (commitStatus.Equals(0))
                throw new DbUpdateException($"Some error occurred white deleting {_typeName} " +
                                            $"with Id={id}");

            return commitStatus > 0;
        }
    }
}