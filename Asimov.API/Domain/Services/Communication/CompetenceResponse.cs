using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Services.Communication
{
    public class CompetenceResponse : BaseResponse<Competence>
    {
        public CompetenceResponse(string message) : base(message)
        {
        }

        public CompetenceResponse(Competence resource) : base(resource)
        {
        }
    }
}