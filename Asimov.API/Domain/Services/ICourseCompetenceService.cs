using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Services
{
    public interface ICourseCompetenceService
    {
        Task<IEnumerable<Competence>> ListByCourseId(int courseId);
    }
}