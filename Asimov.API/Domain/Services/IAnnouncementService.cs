using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Domain.Services
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task<IEnumerable<Announcement>> ListByDirectorIdAsync(int directorId);
        Task<AnnouncementResponse> SaveAsync(Announcement announcement);
        Task<AnnouncementResponse> UpdateAsync(int id, Announcement announcement);
        Task<AnnouncementResponse> DeleteAsync(int id);
    }
}