using Microsoft.AspNetCore.Mvc;
using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.Core.Enums;
using System.Threading.Tasks;

namespace NewsWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class NewsBaseController<TEntity> : ControllerBase where TEntity : class
    {
        #region field
        private readonly IBaseServices<TEntity> _baseServices;
        #endregion
        #region Contructor
        public NewsBaseController(IBaseServices<TEntity> baseServices)
        {
            _baseServices = baseServices;
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _baseServices.GetEntitiesAsync();
            if (result.Total > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var result = _baseServices.GetEntities();
        //    if (result.Data != null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}
        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        [HttpGet("{entityId}")]
        public IActionResult Get(int entityId)
        {
            var result = _baseServices.GetById(entityId);
            if (result.Data == null)
            {
                return NoContent();
            }
            return Ok(result);
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var result = _baseServices.Insert(entity);
            if (result.CodeResult == CodeResult.NotValid)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        /// <summary>
        /// Xoá 
        /// </summary>
        /// <param name="id"> Id thực thể</param>
        /// <returns>Số bản ghi đã xoá</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _baseServices.Delete(id);
            return Ok(entity);
        }
        #endregion
    }
}
