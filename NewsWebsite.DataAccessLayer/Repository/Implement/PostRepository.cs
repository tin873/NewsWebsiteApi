using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Post> GetPostByCategory(int postId)
        {
            var result = _dbContext.Posts.FromSqlRaw("EXEC SP_GETPOSTBYCATEGORYID {0}", postId).ToList();
            return result;
        }

        public IEnumerable<Post> GetSearchPost(string search)
        {
            //var result = _dbContext.Posts.Where(p => p.Title.ToUpper().Contains(search.ToUpper()));
            var result = _dbContext.Posts.FromSqlRaw("EXEC SP_GETPOSTSEARCH {0}", search).ToList();
            return result;
        }

        //public void Update(Post post)
        //{
        //    var postNew = GetById(post.PostId);
        //    postNew.Image = post.Image;
        //    postNew.Title = post.Title;
        //    postNew.Status = post.Status;
        //    postNew.Content = post.Content;
        //    postNew.postId = post.postId;
        //    postNew.CreatedBy = post.CreatedBy;
        //    postNew.CreatedDate = post.CreatedDate;
        //    postNew.ModifiedBy = post.ModifiedBy;
        //    postNew.ModifiedDate = post.ModifiedDate;
        //}
        public int Update(Post post)
        {
            var resutl = _dbContext.Database.ExecuteSqlRaw("EXEC SP_UPDATEpost {0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", post.PostId, post.Title, post.Image, post.Content, post.Status, post.CategoryId, post.CreatedDate, post.CreatedBy, post.ModifiedDate, post.ModifiedBy);
            return resutl;
        }

        public virtual int Insert(Post post)
        {
            var resutl = _dbContext.Database.ExecuteSqlRaw("EXEC SP_ADDPost {0},{1},{2},{3},{4},{5},{6},{7},{8}", post.Title, post.Image, post.Content, post.Status, post.CategoryId, post.CreatedDate, post.CreatedBy, post.ModifiedDate, post.ModifiedBy);
            return resutl;
        }
    }
}
