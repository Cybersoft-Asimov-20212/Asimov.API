using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> ListAsync();
        Task AddAsync(Item item);
        Task<Item> FindByIdAsync(int id);
        Task<IEnumerable<Item>> FindByCourseId(int courseId);
        void Update(Item item);
        void Remove(Item item);
    }
}