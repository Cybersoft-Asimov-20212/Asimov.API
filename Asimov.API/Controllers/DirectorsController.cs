using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Services;
using Asimov.API.Extensions;
using Asimov.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DirectorResource>> GetAllAsync()
        {
            var directors = await _directorService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Director>, IEnumerable<DirectorResource>>(directors);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDirectorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var director = _mapper.Map<SaveDirectorResource, Director>(resource);

            var result = await _directorService.SaveAsync(director);
            if (!result.Success)
                return BadRequest(result.Message);
            var directorResource = _mapper.Map<Director, DirectorResource>(result.Resource);

            return Ok(directorResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDirectorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var director = _mapper.Map<SaveDirectorResource, Director>(resource);

            var result = await _directorService.UpdateAsync(id, director);
            
            if (!result.Success)
                return BadRequest(result.Message);
            var directorResource = _mapper.Map<Director, DirectorResource>(result.Resource);
            
            return Ok(directorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _directorService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            var directorResource = _mapper.Map<Director, DirectorResource>(result.Resource);
            
            return Ok(directorResource);
        }
    }
}