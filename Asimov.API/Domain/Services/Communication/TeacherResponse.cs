using Asimov.API.Domain.Models;
using Asimov.API.Persistence.Repositories;

namespace Asimov.API.Domain.Services.Communication
{
    public class TeacherResponse : BaseResponse<Teacher>
    {
        public TeacherResponse(string message) : base(message)
        {
        }

        public TeacherResponse(Teacher resource) : base(resource)
        {
        }
    }
}