using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Domain.Services;
using Asimov.API.Domain.Services.Communication;
using Microsoft.EntityFrameworkCore.TestModels.Inheritance;

namespace Asimov.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _teacherRepository.ListAsync();
        }
        
        public async Task<TeacherResponse> SaveAsync(Teacher teacher)
        {
            try
            {
                await _teacherRepository.AddAsync(teacher);
                await _unitOfWork.CompleteAsync();

                return new TeacherResponse(teacher);
            }
            catch (Exception e)
            {
                return new TeacherResponse($"An error occurred while saving teacher: {e.Message}");
            }
        }
        
        public async Task<TeacherResponse> UpdateAsync(int id, Teacher teacher)
        {
            var existingTeacher = await _teacherRepository.FindByIdAsync(id);

            if (existingTeacher == null)
                return new TeacherResponse("Teacher not found");
            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.Point = teacher.Point;
            existingTeacher.Age = teacher.Age;
            existingTeacher.Email = teacher.Email;
            existingTeacher.Phone = teacher.Phone;

            try
            {
                _teacherRepository.Update(existingTeacher);
                await _unitOfWork.CompleteAsync();

                return new TeacherResponse(existingTeacher);
            }
            catch (Exception e)
            {
                return new TeacherResponse($"An error occurred while updating teacher: {e.Message}");
            }
        }
        
        public async Task<TeacherResponse> DeleteAsync(int id)
        {
            var existingTeacher = await _teacherRepository.FindByIdAsync(id);

            if (existingTeacher == null)
                return new TeacherResponse("Teacher not found");
            
            try
            {
                _teacherRepository.Remove(existingTeacher);
                await _unitOfWork.CompleteAsync();

                return new TeacherResponse(existingTeacher);
            }
            catch (Exception e)
            {
                return new TeacherResponse($"An error occurred while deleting teacher: {e.Message}");
            }
        }
    }
    
    
}