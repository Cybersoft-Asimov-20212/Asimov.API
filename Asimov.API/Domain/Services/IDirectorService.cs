using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Domain.Services
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>> ListAsync();
        Task<DirectorResponse> SaveAsync(Director director);
        Task<DirectorResponse> UpdateAsync(int id, Director director);
        Task<DirectorResponse> DeleteAsync(int id);

    }
}