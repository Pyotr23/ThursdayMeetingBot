using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThursdayMeetingBot.Libraries.Core.Services;

namespace ThursdayMeetingBot.Libraries.Service.Services
{
    public abstract class BaseService<TDbContext, TDto,TEntity,TKey> : IService<TDto,TEntity,TKey>
    where TDbContext : DbContext
    where TDto : class
    where TEntity : class
    where TKey : IEquatable<TKey>
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        protected BaseService(TDbContext context, IMapper mapper)
        {
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }
        
        public async Task<TDto> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] {id}, cancellationToken);  
            var result = _mapper.Map<TDto>(entity);
            return result;
        }

        public async Task<TDto> CreateAsync(TEntity entityToAdd, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(TEntity entityToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}