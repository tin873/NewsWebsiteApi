using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.Core.Entities;
using NewsWebsite.DataAccessLayer.Entities;

namespace NewsWebsite.BusinessLogic.Services.Interface
{
    public interface IPostServices : IBaseServices<Post>
    {
        /// <summary>
        /// Cập nhật thông tin bài viết
        /// </summary>
        /// <param name="post">bài viết</param>
        ServiceResult Update(Post post);
        /// <summary>
        /// lấy thông tin post từ categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>post thuộc category</returns>
        ServiceResult GetPostByCategoryId(int categoryId);

        /// <summary>
        /// lấy thông tin bài viết theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        ServiceResult GetSearchPost(string search);
    }
}
