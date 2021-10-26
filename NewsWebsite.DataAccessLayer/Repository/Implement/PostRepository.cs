using NewsWebsite.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NewsWebsite.DataAccessLayer.Repository.Implement
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly NewsWebsiteDbContext _dbContext;
        public PostRepository(NewsWebsiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Post> GetSearchPost(string search)
        {
            var result = _dbContext.Posts.Where(p => p.Title.ToUpper().Contains(search.ToUpper()));
            return result;
        }

        public void Update(Post post)
        {
            var postNew = GetById(post.PostId);
            postNew.Image = post.Image;
            postNew.Title = post.Title;
            postNew.Status = post.Status;
            postNew.Content = post.Content;
            postNew.CategoryId = post.CategoryId;
            postNew.CreatedBy = post.CreatedBy;
            postNew.CreatedDate = post.CreatedDate;
            postNew.ModifiedBy = post.ModifiedBy;
            postNew.ModifiedDate = post.ModifiedDate;
        }
    }
}
