using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Persistence.Repositories
{
    public class DirectorRepository : BaseRepository, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Director>> ListAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task AddAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
        }

        public async Task<Director> FindByIdAsync(int id)
        {
            return await _context.Directors.FindAsync(id);
        }

        public void Update(Director director)
        {
            _context.Directors.Update(director);
        }

        public void Remove(Director director)
        {
            _context.Directors.Remove(director);
        }
    }
}