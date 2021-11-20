using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Services.Communication;

namespace Asimov.API.Teachers.Domain.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> ListAsync();
        Task<Teacher> FindByIdAsync(int id);
        Task<IEnumerable<Teacher>> ListByDirectorIdAsync(int directorId);
        Task<TeacherResponse> SaveAsync(Teacher teacher);
        Task<TeacherResponse> UpdateAsync(int id, Teacher teacher);
        Task<TeacherResponse> DeleteAsync(int id);
     
    }
}