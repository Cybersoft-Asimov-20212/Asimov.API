using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Services.Communication
{
    public class AnnouncementResponse : BaseResponse<Announcement>
    {
        public AnnouncementResponse(string message) : base(message)
        {
        }

        public AnnouncementResponse(Announcement resource) : base(resource)
        {
        }
    }
}