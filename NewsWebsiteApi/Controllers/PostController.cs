using Microsoft.AspNetCore.Mvc;
using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.BusinessLogic.Services.Interface;
using NewsWebsite.Core.Entities;
using NewsWebsite.Core.Enums;

namespace NewsWebsiteApi.Controllers
{
    public class PostController : NewsBaseController<Post>
    {
        private readonly IPostServices _postServices;
        public PostController(IBaseServices<Post> baseServices, IPostServices postServices) : base(baseServices)
        {
            _postServices = postServices;
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="post">bài viét</param>
        /// <returns>
        ///  - HttpCode: 201 nếu cập nhật được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        [HttpPut]
        public IActionResult Put([FromBody] Post post)
        {
            var result = _postServices.Update(post);
            if (result.CodeResult == CodeResult.NotValid)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        /// <summary>
        /// lấy bài viết
        /// </summary>
        /// <param name="categoryId">Id danh mục</param>
        /// <returns>
        ///  - HttpCode: 201 nếu cập nhật được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        [HttpGet("GetPostByCategory")]
        public IActionResult GetPostByCategory(int categoryId)
        {
            var result = _postServices.GetPostByCategoryId(categoryId);
            if (result.CodeResult == CodeResult.NotValid)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// lấy bài viết
        /// </summary>
        /// <param name="search">từ khóa tìm kiếm</param>
        /// <returns>
        ///  - HttpCode: 201 nếu cập nhật được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        [HttpGet("GetSearchPost")]
        public IActionResult GetSearchPost(string search)
        {
            var result = _postServices.GetSearchPost(search);
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
        public IActionResult Post([FromBody] Post post)
        {
            var result = _postServices.Insert(post);
            if (result.CodeResult == CodeResult.NotValid)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
