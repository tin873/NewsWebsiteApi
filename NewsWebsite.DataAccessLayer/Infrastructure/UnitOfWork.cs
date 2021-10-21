using System.Threading.Tasks;

namespace NewsWebsite.DataAccessLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private NewsWebsiteDbContext _dbContext;
        public UnitOfWork(NewsWebsiteDbContext dbFactory)
        {
            _dbContext = dbFactory;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
