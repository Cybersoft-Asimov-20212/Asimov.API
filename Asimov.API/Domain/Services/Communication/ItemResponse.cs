using Asimov.API.Domain.Models;

namespace Asimov.API.Domain.Services.Communication
{
    public class ItemResponse : BaseResponse<Item>
    {
        public ItemResponse(string message) : base(message)
        {
        }

        public ItemResponse(Item resource) : base(resource)
        {
        }
    }
}