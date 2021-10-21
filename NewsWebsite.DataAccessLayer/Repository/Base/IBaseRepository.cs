using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities();
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetEntitiesAsync();

        /// <summary>
        /// Lấy thông tin của thực thể theo Id
        /// </summary>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Thực thể có id tương ứng</returns>
        TEntity GetById(int entityId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns> bản ghi thêm mới trong db</returns>
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Insert(TEntity entity);


        /// <summary>
        /// Xoá thực thể
        /// </summary>
        /// <param name="TEntity">thực thể</param>
        /// <returns>int</returns>
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Delete(TEntity entity);

        /// <summary>
        /// tổng số bản ghi
        /// </summary>
        /// <returns>tổng số bản ghi</returns>
        Task<int> Count();
    }
}
