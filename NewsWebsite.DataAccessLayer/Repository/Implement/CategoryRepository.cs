using Microsoft.EntityFrameworkCore;
using NewsWebsite.Core.Entities;

namespace NewsWebsite.DataAccessLayer.Repository.Implement
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly NewsWebsiteDbContext _dbContext;
        public CategoryRepository(NewsWebsiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public void Update(Category category)
        //{
        //    var categoryNew = GetById(category.CategoryId);
        //    categoryNew.CategoryName = category.CategoryName;
        //    categoryNew.CreatedBy = category.CreatedBy;
        //    categoryNew.CreatedDate = category.CreatedDate;
        //    categoryNew.Description = category.Description;
        //    categoryNew.ModifiedBy = category.ModifiedBy;
        //    categoryNew.ModifiedDate = category.ModifiedDate;
        //}
        public int Update(Category category)
        {
            var resutl = _dbContext.Database.ExecuteSqlRaw("EXEC SP_UPDATECATEGORY {0},{1},{2},{3},{4},{5},{6}", category.CategoryId, category.CategoryName, category.Description, category.CreatedDate, category.CreatedBy, category.ModifiedDate, category.ModifiedBy);
            return resutl;
        }
        public int Insert(Category category)
        {
            var result = _dbContext.Database.ExecuteSqlRaw("EXEC SP_ADDCategory {0},{1},{2},{3},{4},{5}", category.CategoryName,category.Description, category.CreatedDate,category.CreatedBy, category.ModifiedDate, category.ModifiedBy);
            return result;
        }
    }
}
