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
    [Route("/api/v1/courses/{courseId}/competences")]
    public class CourseCompetencesController : ControllerBase
    {
        private readonly ICourseCompetenceService _courseCompetenceService;
        private readonly IMapper _mapper;

        public CourseCompetencesController(ICourseCompetenceService courseCompetenceService, IMapper mapper)
        {
            _courseCompetenceService = courseCompetenceService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CompetenceResource>> GetAllByCourseIdAsync(int courseId)
        {
            var competences = await _courseCompetenceService.ListByCourseId(courseId);
            var resources = _mapper.Map<IEnumerable<Competence>, IEnumerable<CompetenceResource>>(competences);

            return resources;
        }
    }
}