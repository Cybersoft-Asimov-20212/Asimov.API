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
        private readonly IDirectorRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(ITeacherRepository teacherRepository, IDirectorRepository directorRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _teacherRepository.ListAsync();
        }

        public async Task<IEnumerable<Teacher>> ListByDirectorIdAsync(int directorId)
        {
            return await _teacherRepository.FindByDirectorId(directorId);
        }

        public async Task<TeacherResponse> SaveAsync(Teacher teacher)
        {
            var existingDirector = _directorRepository.FindByIdAsync(teacher.DirectorId);

            if (existingDirector == null)
                return new TeacherResponse("Invalid Director");
            
            var existingTeacherWithEmail = await _teacherRepository.FindByEmailAsync(teacher.Email);
            
            if(existingTeacherWithEmail != null)
                return new TeacherResponse("Teacher Email already exist.");

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
            
            var existingDirector = _directorRepository.FindByIdAsync(teacher.DirectorId);

            if (existingDirector == null)
                return new TeacherResponse("Invalid Director");
            
            var existingTeacherWithEmail = await _teacherRepository.FindByEmailAsync(teacher.Email);
            
            if(existingTeacherWithEmail != null && existingTeacherWithEmail.Id != existingTeacher.Id)
                return new TeacherResponse("Teacher Email already exist.");
            
            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.Point = teacher.Point;
            existingTeacher.Age = teacher.Age;
            existingTeacher.Email = teacher.Email;
            existingTeacher.Phone = teacher.Phone;
            existingTeacher.DirectorId = teacher.DirectorId;

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