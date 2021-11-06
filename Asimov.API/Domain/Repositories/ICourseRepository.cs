using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Repositories
{
    public interface ICourseRepository
    {

        Task<IEnumerable<Course>> ListAsync();

        Task AddAsync(Course course);

        Task<Course> FindByIdAsync(int id);

        void Update(Course course);

        void Remove(Course course);
    }
}