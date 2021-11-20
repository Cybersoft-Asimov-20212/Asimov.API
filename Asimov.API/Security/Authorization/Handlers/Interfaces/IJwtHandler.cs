using Asimov.API.Directors.Domain.Models;

namespace Asimov.API.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(Director user);
        public int? ValidateToken(string token);
    }
}