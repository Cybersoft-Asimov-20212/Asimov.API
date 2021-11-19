using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Domain.Services
{
    public interface ICompetenceService
    {
        Task<IEnumerable<Competence>> ListAsync();
        Task<CompetenceResponse> SaveAsync(Competence competence);
        Task<CompetenceResponse> UpdateAsync(int id, Competence competence);
        Task<CompetenceResponse> DeleteAsync(int id);
    }
}