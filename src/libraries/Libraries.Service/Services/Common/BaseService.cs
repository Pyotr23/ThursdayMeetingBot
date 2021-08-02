using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ThursdayMeetingBot.Libraries.Service.Services.Common
{
    /// <summary>
    ///     Base service with minimum functionality.
    /// </summary>
    /// <typeparam name="TDbContext"> DbContext. </typeparam>
    public abstract class BaseService<TDbContext>
    where TDbContext : DbContext
    {
        protected TDbContext DbContext { get; }

        protected IMapper Mapper { get; }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="dbContext"> DbContext. </param>
        /// <param name="mapper"> Mapper. </param>
        protected BaseService(TDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
    }
}