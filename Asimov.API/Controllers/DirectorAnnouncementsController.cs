using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services;
using Asimov.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/directors/{directorId}/announcements")]
    public class DirectorAnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        
        public DirectorAnnouncementsController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<AnnouncementResource>> GetAllByDirectorIdAsync(int directorId)
        {
            var announcements = await _announcementService.ListByDirectorIdAsync(directorId);
            var resources = _mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementResource>>(announcements);

            return resources;
        }
    }
}