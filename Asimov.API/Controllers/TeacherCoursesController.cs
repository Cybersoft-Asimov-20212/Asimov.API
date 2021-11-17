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
    [Route("/api/v1/teachers/{teacherId}/courses")]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly ITeacherCourseService _teacherCourseService;
        private readonly IMapper _mapper;

        public TeacherCoursesController(ITeacherCourseService teacherCourseService, IMapper mapper)
        {
            _teacherCourseService = teacherCourseService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CourseResource>> GetAllByTeacherIdAsync(int teacherId)
        {
            var courses = await _teacherCourseService.ListByTeacherId(teacherId);
            var resources = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);

            return resources;
        }
    }
}