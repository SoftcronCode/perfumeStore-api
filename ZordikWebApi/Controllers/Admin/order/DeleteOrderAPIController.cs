using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.order;
using Setup.ITF.Admin.product.size;
using Setup.Request.Admin.order;
using Setup.Request.Admin.product.size;
using Setup.Response.Admin.product.size;

namespace ZordikWebApi.Controllers.Admin.order
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteOrderAPIController : ControllerBase
    {
        private readonly IOrderDelete _orderDelete;

        public DeleteOrderAPIController(IOrderDelete orderDelete)
        {
            _orderDelete = orderDelete;
        }

        [HttpPost]
        public CommonResponse<OrderDeleteResponse> DeleteOrder([FromBody] OrderDeleteRequest request)
        {
            return _orderDelete.DeleteOrder(request);
        }
    }
}
