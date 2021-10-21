using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.BusinessLogic.Services.Interface;
using NewsWebsite.Core.Entities;
using NewsWebsite.Core.Enums;
using NewsWebsite.DataAccessLayer.Entities;
using NewsWebsite.DataAccessLayer.Infrastructure;
using NewsWebsite.DataAccessLayer.Repository;

namespace NewsWebsite.BusinessLogic.Services.Implement
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        #region field
        private readonly ICategoryRepository _categoryRepository;
        #endregion
        #region contructor
        public CategoryServices(IUnitOfWork unitOfWork, IBaseRepository<Category> baseRepository, ICategoryRepository categoryRepository) : base(unitOfWork, baseRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region emplement
        public ServiceResult Update(Category category)
        {
            var result = _categoryRepository.GetById(category.CategoryId);
            if (result != null)
            {
                _categoryRepository.Update(category);
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
        #endregion
    }
}
