﻿using NewsWebsite.BusinessLogic.BaseServices;
using NewsWebsite.Core.Entities;
using NewsWebsite.DataAccessLayer.Entities;

namespace NewsWebsite.BusinessLogic.Services.Interface
{
    public interface ICategoryServices : IBaseServices<Category>
    {
        /// <summary>
        /// Cập nhật thông tin danh mục
        /// </summary>
        /// <param name="category">danh mục</param>
        ServiceResult Update(Category category);
    }
}
