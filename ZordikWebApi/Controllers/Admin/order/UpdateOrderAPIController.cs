using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.order;
using Setup.Request.Admin.order;

namespace ZordikWebApi.Controllers.Admin.order
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateOrderAPIController : ControllerBase
    {
        private readonly IOrderUpdate _orderUpdate;

        public UpdateOrderAPIController(IOrderUpdate orderUpdate)
        {
            _orderUpdate = orderUpdate;
        }

        [HttpPost]
        public CommonResponse<OrderUpdateResponse> UpdateOrder(OrderUpdateRequest request)
        {
            return _orderUpdate.UpdateOrder(request);
        }
    }
}
