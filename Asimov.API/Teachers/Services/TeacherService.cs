using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Security.Authorization.Handlers.Interfaces;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Security.Exceptions;
using Asimov.API.Shared.Domain.Repositories;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Repositories;
using Asimov.API.Teachers.Domain.Services;
using Asimov.API.Teachers.Domain.Services.Communication;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Asimov.API.Teachers.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IDirectorRepository directorRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponseTeacher> Authenticate(AuthenticateRequest request)
        {
            var teacher = await _teacherRepository.FindByEmailAsync(request.Email);
            
            if (teacher == null || !BCryptNet.Verify(request.Password, teacher.PasswordHash))
                throw new AppException("Email or password is incorrect.");
            
            var response = _mapper.Map<AuthenticateResponseTeacher>(teacher);
            response.Token = _jwtHandler.GenerateTokenForTeacher(teacher);
            return response;
        }

        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _teacherRepository.ListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await _teacherRepository.FindByIdAsync(id);
            if (teacher == null) throw new KeyNotFoundException("User not found");
            return teacher;
        }

        public async Task<Teacher> FindByIdAsync(int id)
        {
            return await _teacherRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Teacher>> ListByDirectorIdAsync(int directorId)
        {
            return await _teacherRepository.FindByDirectorId(directorId);
        }

        public async Task RegisterAsync(RegisterRequestTeacher request)
        {
            // Validate
            if (_teacherRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            // Map request to User 
            var teacher = _mapper.Map<Teacher>(request);
            
            // Hash Password
            teacher.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Save User
            try
            {
                await _teacherRepository.AddAsync(teacher);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequestTeacher request)
        {
            var teacher = GetById(id);
            
            // Validate
            if (_teacherRepository.ExistByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            // Hash Password if entered
            if (!string.IsNullOrEmpty(request.Password))
                teacher.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Map request to User
            _mapper.Map(request, teacher);
            
            try
            {
                _teacherRepository.Update(teacher);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = GetById(id);
            
            try
            {
                _teacherRepository.Remove(teacher);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");
            }
        }
        
        private Teacher GetById(int id)
        {
            var teacher = _teacherRepository.FindById(id);
            if (teacher == null) throw new KeyNotFoundException("Teacher not found.");
            return teacher;
        }

        /*public async Task<TeacherResponse> SaveAsync(Teacher teacher)
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
        }*/
    }
    
    
}