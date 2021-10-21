using NewsWebsite.Core.Enums;
using NewsWebsite.DataAccessLayer.Entities;
using NewsWebsite.DataAccessLayer.Infrastructure;
using NewsWebsite.DataAccessLayer.Repository;
using System.Threading.Tasks;

namespace NewsWebsite.BusinessLogic.BaseServices
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        #region field
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseRepository<TEntity> _baseReposistory;
        protected readonly ServiceResult _serviceResult;
        #endregion
        #region Contructor
        public BaseServices(IUnitOfWork unitOfWork, IBaseRepository<TEntity> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseReposistory = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
        #region implement
        public ServiceResult Delete(int entityId)
        {
            var entity = _baseReposistory.GetById(entityId);
            if (entity != null)
            {
                _baseReposistory.Delete(entity);
                var result = _unitOfWork.Commit();
                if (result > 0)
                {
                    _serviceResult.Data = result;
                    _serviceResult.Msg = "Xóa bản ghi thành công.";
                    _serviceResult.CodeResult = CodeResult.Success;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Msg = "Lỗi không xóa được bản ghi.";
                    _serviceResult.CodeResult = CodeResult.Exeption;
                    return _serviceResult;
                }
            }
            else
            {
                _serviceResult.Data = null;
                _serviceResult.Msg = "Không tồn tại bản ghi.";
                _serviceResult.CodeResult = CodeResult.NotFound;
                return _serviceResult;
            }
        }

        public ServiceResult GetById(int entityId)
        {
            var result = _baseReposistory.GetById(entityId);
            if (result != null)
            {
                _serviceResult.Data = result;
                _serviceResult.Msg = "Tìm thấy một bản ghi.";
                _serviceResult.CodeResult = CodeResult.Success;
                return _serviceResult;
            }
            else
            {
                _serviceResult.Data = null;
                _serviceResult.Msg = "Không tồn tại bản ghi.";
                _serviceResult.CodeResult = CodeResult.NotFound;
                return _serviceResult;
            }
        }

        public ServiceResult GetEntities()
        {
            var result = _baseReposistory.GetEntities();
            if (result != null)
            {
                _serviceResult.Data = result;
                _serviceResult.Msg = "Thành công.";
                _serviceResult.CodeResult = CodeResult.Success;
                return _serviceResult;
            }
            else
            {
                _serviceResult.Data = null;
                _serviceResult.Msg = "Không tìm thấy bản ghi nào.";
                _serviceResult.CodeResult = CodeResult.NotFound;
                return _serviceResult;
            }
        }

        public async Task<ServiceResult> GetEntitiesAsync()
        {
            var result = await _baseReposistory.GetEntitiesAsync();
            var count = await _baseReposistory.Count();
            if (result != null)
            {
                _serviceResult.Data = result;
                _serviceResult.Msg = "Thành công.";
                _serviceResult.CodeResult = CodeResult.Success;
                _serviceResult.Total = count;
                return _serviceResult;
            }
            else
            {
                _serviceResult.Data = null;
                _serviceResult.Msg = "Không tìm thấy bản ghi nào.";
                _serviceResult.CodeResult = CodeResult.NotFound;
                return _serviceResult;
            }
        }

        public ServiceResult Insert(TEntity entity)
        {
            var result = _baseReposistory.Insert(entity);
            if (result.Entity != null)
            {
                if(_unitOfWork.Commit() > 0)
                {
                    _serviceResult.Data = result.Entity;
                    _serviceResult.Msg = "Thêm mới thành công.";
                    _serviceResult.CodeResult = CodeResult.Success;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Data = null;
                    _serviceResult.Msg = "Lỗi không thể thêm mới.";
                    _serviceResult.CodeResult = CodeResult.NotValid;
                    return _serviceResult;
                }
            }
            else
            {
                _serviceResult.Data = null;
                _serviceResult.Msg = "Lỗi không thể thêm mới.";
                _serviceResult.CodeResult = CodeResult.Exeption;
                return _serviceResult;
            }
        }

        #endregion
    }
}
