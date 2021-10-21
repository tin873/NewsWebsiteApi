using NewsWebsite.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace NewsWebsite.BusinessLogic.BaseServices
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns></returns>
        ServiceResult GetEntities();
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult> GetEntitiesAsync();

        /// <summary>
        /// Lấy thông tin của thực thể theo Id
        /// </summary>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>Thực thể có id tương ứng</returns>
        ServiceResult GetById(int entityId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>số nguyên</returns>
        ServiceResult Insert(TEntity entity);


        /// <summary>
        /// Xoá thực thể
        /// </summary>
        /// <param name="TEntity">thực thể</param>
        /// <returns>bool</returns>
        ServiceResult Delete(int entityId);
    }
}
