using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> ListAsync();
        Task AddAsync(Teacher teacher);
        Task<Teacher> FindByIdAsync(int id);
        Task<Teacher> FindByEmailAsync(string email);
        Task<IEnumerable<Teacher>> FindByDirectorId(int directorId);
        void Update(Teacher teacher);
        void Remove(Teacher teacher);
    }
}