﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Services
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly ITeacherCourseRepository _teacherCourseRepository;
        private readonly ICourseRepository _courseRepository;

        public TeacherCourseService(ITeacherCourseRepository teacherCourseRepository, ICourseRepository courseRepository)
        {
            _teacherCourseRepository = teacherCourseRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> ListByTeacherId(int teacherId)
        {
            var teacherCourse = await _teacherCourseRepository.FindByTeacherId(teacherId);
            IEnumerable<Course> courses = new List<Course>();

            foreach (var c in teacherCourse)
            {
                var course = await _courseRepository.FindByIdAsync(c.CourseId);
                courses = courses.Append(course);
            }

            return courses.ToList();
        }
    }
}