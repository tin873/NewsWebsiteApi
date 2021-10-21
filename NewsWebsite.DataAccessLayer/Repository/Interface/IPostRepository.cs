using NewsWebsite.Core.Entities;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="category">bài viết</param>
        void Update(Post post);

    }
}
