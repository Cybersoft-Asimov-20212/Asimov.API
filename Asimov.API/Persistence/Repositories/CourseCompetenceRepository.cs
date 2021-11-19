using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Persistence.Repositories
{
    public class CourseCompetenceRepository : BaseRepository, ICourseCompetenceRepository
    {
        public CourseCompetenceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CourseCompetence>> FindByCourseId(int courseId)
        {
            return await _context.CourseCompetences
                .Where(p => p.CourseId == courseId)
                .Include(p => p.Competence)
                .ToListAsync();
        }
    }
}