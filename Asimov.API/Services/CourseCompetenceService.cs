using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Domain.Services;

namespace Asimov.API.Services
{
    public class CourseCompetenceService : ICourseCompetenceService
    {
        private readonly ICourseCompetenceRepository _courseCompetenceRepository;
        private readonly ICompetenceRepository _competenceRepository;


        public CourseCompetenceService(ICourseCompetenceRepository courseCompetenceRepository, ICompetenceRepository competenceRepository)
        {
            _courseCompetenceRepository = courseCompetenceRepository;
            _competenceRepository = competenceRepository;
        }

        public async Task<IEnumerable<Competence>> ListByCourseId(int courseId)
        {
            var courseCompetence = await _courseCompetenceRepository.FindByCourseId(courseId);
            IEnumerable<Competence> competences = new List<Competence>();

            foreach (var c in courseCompetence)
            {
                var competence = await _competenceRepository.FindByIdAsync(c.CompetenceId);
                competences = competences.Append(competence);
            }

            return competences.ToList();
        }
    }
}