using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Persistence.Repositories
{
    public class TeacherCourseRepository : BaseRepository, ITeacherCourseRepository
    {
        public TeacherCourseRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<TeacherCourse>> FindByTeacherId(int teacherId)
        {
            return await _context.TeacherCourses
                .Where(p => p.TeacherId == teacherId)
                .Include(p => p.Course)
                .ToListAsync();
        }
    }
}