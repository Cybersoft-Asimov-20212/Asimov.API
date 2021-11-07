using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Domain.Services;
using Asimov.API.Domain.Services.Communication;

namespace Asimov.API.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DirectorService(IDirectorRepository directorRepository, IUnitOfWork unitOfWork)
        {
            _directorRepository = directorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Director>> ListAsync()
        {
            return await _directorRepository.ListAsync();
        }

        public async Task<DirectorResponse> SaveAsync(Director director)
        {
            try
            {
                await _directorRepository.AddAsync(director);
                await _unitOfWork.CompleteAsync();

                return new DirectorResponse(director);
            }
            catch (Exception e)
            {
                return new DirectorResponse($"An error occurred while saving director: {e.Message}");
            }
        }

        public async Task<DirectorResponse> UpdateAsync(int id, Director director)
        {
            var existingDirector = await _directorRepository.FindByIdAsync(id);

            if (existingDirector == null)
                return new DirectorResponse("Director not found");
            existingDirector.FirstName = director.FirstName;
            existingDirector.LastName = director.LastName;
            existingDirector.Age = director.Age;
            existingDirector.Email = director.Email;
            existingDirector.Phone = director.Phone;

            try
            {
                _directorRepository.Update(existingDirector);
                await _unitOfWork.CompleteAsync();

                return new DirectorResponse(existingDirector);
            }
            catch (Exception e)
            {
                return new DirectorResponse($"An error occurred while updating director: {e.Message}");
            }
        }

        public async Task<DirectorResponse> DeleteAsync(int id)
        {
            var existingDirector = await _directorRepository.FindByIdAsync(id);

            if (existingDirector == null)
                return new DirectorResponse("Director not found");
            
            try
            {
                _directorRepository.Remove(existingDirector);
                await _unitOfWork.CompleteAsync();

                return new DirectorResponse(existingDirector);
            }
            catch (Exception e)
            {
                return new DirectorResponse($"An error occurred while deleting director: {e.Message}");
            }
        }
    }
}