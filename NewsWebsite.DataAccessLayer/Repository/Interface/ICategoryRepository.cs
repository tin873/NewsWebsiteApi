using NewsWebsite.Core.Entities;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="category">danh mục</param>
        void Update(Category category);


    }
}
