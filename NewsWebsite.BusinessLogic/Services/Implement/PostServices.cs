using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.BusinessLogic.Services.Interface;
using NewsWebsite.Core.Entities;
using NewsWebsite.Core.Enums;
using NewsWebsite.DataAccessLayer.Entities;
using NewsWebsite.DataAccessLayer.Infrastructure;
using NewsWebsite.DataAccessLayer.Repository;
using System.Linq;

namespace NewsWebsite.BusinessLogic.Services.Implement
{
    public class PostServices : BaseServices<Post>, IPostServices
    {
        #region field
        private readonly IPostRepository _postRepository;
        #endregion
        #region contructor
        public PostServices(IUnitOfWork unitOfWork, IBaseRepository<Post> baseRepository, IPostRepository postRepository) : base(unitOfWork, baseRepository)
        {
            _postRepository = postRepository;
        }

        #endregion

        #region emplement
        public ServiceResult Update(Post post)
        {
            var result = _postRepository.GetById(post.PostId);
            if (result != null)
            {
                _postRepository.Update(post);
                if (_unitOfWork.Commit() > 0)
                {
                    _serviceResult.Data = 1;
                    _serviceResult.Msg = "Sửa bản ghi thành công.";
                    _serviceResult.CodeResult = CodeResult.Success;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Data = 0;
                    _serviceResult.Msg = "Sửa bản ghi không thành công.";
                    _serviceResult.CodeResult = CodeResult.Exeption;
                    return _serviceResult;
                }
            }
            else
            {
                _serviceResult.Data = 0;
                _serviceResult.Msg = "Dữ liệu không tồn tại.";
                _serviceResult.CodeResult = CodeResult.NotValid;
                return _serviceResult;
            }
        }
        public ServiceResult GetPostByCategoryId(int categoryId)
        {
            var posts = _postRepository.GetEntities().ToList();
            var result = posts.Where(x => x.CategoryId == categoryId).ToList();
            if(result != null)
            {
                _serviceResult.Data = result;
                _serviceResult.Msg = "lấy thông tin thành công.";
                _serviceResult.CodeResult = CodeResult.Success;
                return _serviceResult;
            }
            else
            {
                _serviceResult.Data = null;
                _serviceResult.Msg = "không tồn tại bài viết có danh mục này.";
                _serviceResult.CodeResult = CodeResult.NotFound;
                return _serviceResult;
            }
        }
        #endregion
    }
}
