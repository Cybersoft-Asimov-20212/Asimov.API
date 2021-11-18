using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Repositories
{
    public interface ICourseCompetenceRepository
    {
        public Task<IEnumerable<CourseCompetence>> FindByCourseId(int courseId);
    }
}