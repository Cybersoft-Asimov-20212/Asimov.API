using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Repositories
{
    public interface ITeacherCourseRepository
    {
        public Task<IEnumerable<TeacherCourse>> FindByTeacherId(int teacherId);
    }
}