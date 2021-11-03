using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Services.Communication
{
    public class DirectorResponse : BaseResponse<Director>
    {
        public DirectorResponse(string message) : base(message)
        {
        }

        public DirectorResponse(Director resource) : base(resource)
        {
        }
    }
}