using NewsWebsite.Core.Entities;
using System.Collections.Generic;

namespace NewsWebsite.DataAccessLayer.Repository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        /// <summary>
        /// Cập nhật thông tin thực thể
        /// </summary>
        /// <param name="category">bài viết</param>
        int Update(Post post);

        /// <summary>
        /// Lấy toàn bộ dữ liệu có tên trùng với tham số truyền vào 
        /// </summary>
        /// <param name="search">dữ liệu seach</param>
        /// <returns>danh sách bài viết</returns>
        IEnumerable<Post> GetSearchPost(string search);

        /// <summary>
        /// Lấy toàn bộ dữ liệu có tên trùng với tham số truyền vào 
        /// </summary>
        /// <param name="categoryId">mã danh mục</param>
        /// <returns>danh sách bài viết</returns>
        IEnumerable<Post> GetPostByCategory(int categoryId);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="post">Thực thể</param>
        /// <returns> bản ghi thêm mới trong db</returns>
        int Insert(Post post);

    }
}
