using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Persistence.Repositories
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _context.Teachers
                .Include(p=>p.Director)
                .ToListAsync();
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
        }
        
        public async Task<Teacher> FindByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(p => p.Director)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Teacher> FindByEmailAsync(string email)
        {
            return await _context.Teachers
                .Include(p => p.Director)
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<Teacher>> FindByDirectorId(int directorId)
        {
            return await _context.Teachers
                .Where(p => p.DirectorId == directorId)
                .Include(p => p.Director)
                .ToListAsync();
        }

        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
        }

        public void Remove(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }
        
    }
}