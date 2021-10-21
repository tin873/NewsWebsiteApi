using NewsWebsite.Core.Entities;

namespace NewsWebsite.DataAccessLayer.Repository.Implement
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NewsWebsiteDbContext dbContext) : base(dbContext)
        { }

        public void Update(Category category)
        {
            var categoryNew = GetById(category.CategoryId);
            categoryNew.CategoryName = category.CategoryName;
            categoryNew.CreatedBy = category.CreatedBy;
            categoryNew.CreatedDate = category.CreatedDate;
            categoryNew.Description = category.Description;
            categoryNew.ModifiedBy = category.ModifiedBy;
            categoryNew.ModifiedDate = category.ModifiedDate;
        }
    }
}
