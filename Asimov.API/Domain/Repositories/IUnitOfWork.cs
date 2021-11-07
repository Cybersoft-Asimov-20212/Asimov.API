using System.Threading.Tasks;

namespace Asimov.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}