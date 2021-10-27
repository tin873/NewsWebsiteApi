using NewsWebsite.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="category">danh mục</param>
        int Update(Category category);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="category">Thực thể</param>
        /// <returns> bản ghi thêm mới trong db</returns>
        int Insert(Category category);
    }
}
