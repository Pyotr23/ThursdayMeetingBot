using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.Common;

namespace ThursdayMeetingBot.Libraries.Service.Services.Common
{
    /// <summary>
    ///     Base service with context and database set.
    /// </summary>
    /// <typeparam name="TDbContext"> DbContext. </typeparam>
    /// <typeparam name="TEntity"> Entity. </typeparam>
    /// <typeparam name="TKey"> Unique identificator of entity. </typeparam>
    public abstract class BaseService<TDbContext, TEntity, TKey>
    where TDbContext : DbContext
    where TEntity : AggregatedEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        protected TDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
        protected IMapper Mapper { get; }
        protected ILogger<BaseService<TDbContext, TEntity, TKey>> Logger { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="dbContext"> DbContext. </param>
        /// <param name="mapper"> Mapper. </param>
        protected BaseService(TDbContext dbContext, 
            IMapper mapper, 
            ILogger<BaseService<TDbContext, TEntity, TKey>> logger)
        {
            DbContext = dbContext;
            Mapper = mapper;
            Logger = logger;
        }
    }
}