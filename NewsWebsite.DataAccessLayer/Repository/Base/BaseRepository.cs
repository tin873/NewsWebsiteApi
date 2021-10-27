using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region field
        private readonly DbSet<TEntity> _dbSet;
        private readonly NewsWebsiteDbContext _dbContext;
        protected string _tableName = string.Empty;
        #endregion
        #region Contructor
        public BaseRepository(NewsWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _tableName = typeof(TEntity).Name;
        }
        #endregion
        #region Implement
     

        public virtual int Delete(int entityId)
        {
            var result = _dbContext.Database.ExecuteSqlRaw("EXEC SP_DELETE" + $"{_tableName} {entityId}");
            return result;
        }

        public virtual TEntity GetById(int entityId)
        {
            var result = _dbSet.FromSqlRaw("EXEC SP_GET" + $"{_tableName}BYID {entityId}").ToList();
            return result.FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            var result = _dbSet.FromSqlRaw("EXEC SP_GETALL" + $"{_tableName}");
            return result;
        }

        public virtual Task<int> Count()
        {
            return _dbSet.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        //private string ParamString(TEntity entity)
        //{
        //    //lấy danh sách properties có trong thực thể
        //    var properties = entity.GetType().GetProperties();
        //    //khởi tạo dynamicParameters
        //    var parameters = $"";
        //    //duyệt từng properties
        //    foreach (var property in properties)
        //    {
        //        //lấy tên property
        //        var propertyName = property.Name;
        //        //lấy giá trị property
        //        var propertyValue = property.GetValue(entity);
        //        //lấy kiểu dữ liệu của property
        //        var propertyType = property.PropertyType;
        //        //so sánh kiểm tra kiểu dữ liệu của property và gán vào parameters
        //        if (propertyType == typeof(int) && propertyName == "CategoryId" && _tableName == "Post")
        //        {
        //            parameters += $"{propertyValue},";
        //        }
        //        else if(propertyType == typeof(int)) { }
        //        else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
        //        {
        //            parameters += $"{propertyValue},";
        //        }
        //        else if(propertyName == "Posts" || propertyName == "Category"){}
        //        else if(propertyValue != null)
        //        {
        //            parameters += $"{propertyValue},";
        //        }

        //    }
        //    return parameters;
        //}

        //public virtual Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Delete(TEntity entity)
        //{
        //    if (_dbContext.Entry(entity).State == EntityState.Detached)
        //    {
        //        _dbSet.Attach(entity);
        //    }
        //    return _dbSet.Remove(entity);
        //}

        //public virtual TEntity GetById(int entityId)
        //{
        //    return _dbSet.Find(entityId);
        //}

        //public virtual IEnumerable<TEntity> GetEntities()
        //{
        //    return _dbSet;
        //}

        //public virtual Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Insert(TEntity entity)
        //{
        //    return _dbSet.Add(entity);
        //}

        //public virtual Task<int> Count()
        //{
        //    return _dbSet.CountAsync();
        //}

        //public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        //{
        //    return await _dbSet.ToListAsync();
        //}
        #endregion
    }
}
