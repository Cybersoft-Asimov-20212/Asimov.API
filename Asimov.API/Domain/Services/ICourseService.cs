using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Domain.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> ListAsync();
        Task<Course> FindByIdAsync(int id);

        Task<CourseResponse> SaveAsync(Course course);

        Task<CourseResponse> UpdateAsync(int id, Course course);

        Task<CourseResponse> DeleteAsync(int id);
    }
}