using System.Threading.Tasks;

namespace NewsWebsite.DataAccessLayer.Infrastructure
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
