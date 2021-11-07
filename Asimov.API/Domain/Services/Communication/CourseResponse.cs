using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Services.Communication
{
    public class CourseResponse : BaseResponse<Course>
    {
        public CourseResponse(string message) : base(message)
        {
        }

        public CourseResponse(Course resource) : base(resource)
        {
        }
    }
}