using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> ListAsync();
        Task AddAsync(Director director);
        Task<Director> FindByIdAsync(int id);
        void Update(Director director);
        void Remove(Director director);
    }
}