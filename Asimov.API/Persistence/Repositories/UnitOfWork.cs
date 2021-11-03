using System.Threading.Tasks;
using Asimov.API.Domain.Repositories;
using Asimov.API.Persistence.Contexts;

namespace Asimov.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}