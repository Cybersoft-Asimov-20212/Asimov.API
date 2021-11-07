using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Domain.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> ListAsync();
        Task<IEnumerable<Item>> ListByCourseIdAsync(int courseId);
        Task<ItemResponse> SaveAsync(Item item);
        Task<ItemResponse> UpdateAsync(int id, Item item);
        Task<ItemResponse> DeleteAsync(int id);
    }
}