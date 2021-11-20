﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Shared.Extensions;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Services;
using Asimov.API.Teachers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Teachers.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TeachersController : ControllerBase
    {
       private readonly ITeacherService _teacherService;
       private readonly IMapper _mapper;
       
       public TeachersController(ITeacherService teacherService, IMapper mapper)
       {
           _teacherService = teacherService;
           _mapper = mapper;
       }
       
       [HttpGet]
       public async Task<IEnumerable<TeacherResource>> GetAllAsync()
       {
           var teachers = await _teacherService.ListAsync();

           var resources = _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResource>>(teachers);
           return resources;
       }

       [HttpGet("{id}")]
       public async Task<TeacherResource> GetByIdAsync(int id)
       {
           var teacher = await _teacherService.FindByIdAsync(id);

           var resource = _mapper.Map<Teacher, TeacherResource>(teacher);
           return resource;
       }

       [HttpPost]
       public async Task<IActionResult> PostAsync([FromBody] SaveTeacherResource resource)
       {
           if (!ModelState.IsValid)
               return BadRequest(ModelState.GetErrorMessages());

           var teacher = _mapper.Map<SaveTeacherResource, Teacher>(resource);

           var result= await _teacherService.SaveAsync(teacher);
           
           if (!result.Success)
               return BadRequest(result.Message);
           
           var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Resource);

           return Ok(teacherResource);
       }
       
       [HttpPut("{id}")]
       public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTeacherResource resource)
       {
           if (!ModelState.IsValid)
               return BadRequest(ModelState.GetErrorMessages());

           var teacher = _mapper.Map<SaveTeacherResource, Teacher>(resource);

           var result = await _teacherService.UpdateAsync(id, teacher);
            
           if (!result.Success)
               return BadRequest(result.Message);
           
           var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Resource);
            
           return Ok(teacherResource);
       }
       
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteAsync(int id)
       {
           var result = await _teacherService.DeleteAsync(id);
            
           if (!result.Success)
               return BadRequest(result.Message);
           
           var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Resource);
            
           return Ok(teacherResource);
       }
    }
}