using Microsoft.AspNetCore.Mvc;
using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.BusinessLogic.Services.Interface;
using NewsWebsite.Core.Entities;
using NewsWebsite.Core.Enums;

namespace NewsWebsiteApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/v1/[controller]s")]
    [ApiController]
    public class CategoryController : NewsBaseController<Category>
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(IBaseServices<Category> baseServices, ICategoryServices categoryServices) : base(baseServices)
        {
            _categoryServices = categoryServices;
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="category">danh mục</param>
        /// <returns>
        ///  - HttpCode: 201 nếu cập nhật được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            var result = _categoryServices.Update(category);
            if (result.CodeResult == CodeResult.NotValid)
            {
                return BadRequest(result);
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
        public IActionResult Post([FromBody] Category category)
        {
            var result = _categoryServices.Insert(category);
            if (result.CodeResult == CodeResult.NotValid)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
