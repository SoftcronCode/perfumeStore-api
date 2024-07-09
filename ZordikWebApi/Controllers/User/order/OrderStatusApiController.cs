using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.order;
using Setup.Request.User.order;
using Setup.Response.User.order;

namespace ZordikWebApi.Controllers.User.order
{
    [Route("api/[action]")]
    [ApiController]
    public class OrderStatusApiController : ControllerBase
    {

        private readonly IOrderStatus _orderStatus;

        public OrderStatusApiController(IOrderStatus orderStatus)
        {
            _orderStatus = orderStatus;
        }

        [HttpPost]
        public CommonResponse<OrderStatusResponse> UpdateOrderStatus([FromBody] OrderStatusRequest Objrequest)
        {
            return _orderStatus.UpdateOrderStatus(Objrequest);
        }
    }


}
