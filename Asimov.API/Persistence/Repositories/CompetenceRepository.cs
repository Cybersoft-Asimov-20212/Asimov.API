using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Domain.Models;
using Asimov.API.Domain.Repositories;
using Asimov.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Persistence.Repositories
{
    public class CompetenceRepository : BaseRepository, ICompetenceRepository
    {
        public CompetenceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Competence>> ListAsync()
        {
            return await _context.Competences.ToListAsync();
        }

        public async Task AddAsync(Competence competence)
        {
            await _context.Competences.AddAsync(competence);
        }

        public async Task<Competence> FindByIdAsync(int id)
        {
            return await _context.Competences.FindAsync(id);
        }

        public void Update(Competence competence)
        {
            _context.Competences.Update(competence);
        }

        public void Remove(Competence competence)
        {
            _context.Competences.Remove(competence);
        }
    }
}