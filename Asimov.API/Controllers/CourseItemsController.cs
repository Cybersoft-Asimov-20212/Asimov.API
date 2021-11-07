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
    [Route("/api/v1/courses/{courseId}/items")]
    public class CourseItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public CourseItemsController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemResource>> GetAllByCourseIdAsync(int courseId)
        {
            var items = await _itemService.ListByCourseIdAsync(courseId);
            var resources = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemResource>>(items);

            return resources;
        }
    }
}