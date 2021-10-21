using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region field
        private readonly DbSet<TEntity> _dbSet;
        private readonly NewsWebsiteDbContext _dbContext;
        #endregion
        #region Contructor
        public BaseRepository(NewsWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        #endregion
        #region Implement
        public virtual Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            return _dbSet.Remove(entity);
        }

        public virtual TEntity GetById(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            return _dbSet;
        }

        public virtual Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Insert(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual Task<int> Count()
        {
            return _dbSet.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        {
            return await _dbSet.ToListAsync();
        }
        #endregion
    }
}
