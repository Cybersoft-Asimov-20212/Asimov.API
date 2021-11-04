using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Domain.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> ListAsync();
        Task<TeacherResponse> SaveAsync(Teacher teacher);
        Task<TeacherResponse> UpdateAsync(int id, Teacher teacher);
        Task<TeacherResponse> DeleteAsync(int id);
     
    }
}