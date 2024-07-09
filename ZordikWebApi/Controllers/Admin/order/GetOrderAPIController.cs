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
    public class GetOrderAPIController : ControllerBase
    {
        private readonly IGetOrder _getOrder;

        public GetOrderAPIController(IGetOrder getOrder)
        {
            _getOrder = getOrder;
        }

        [HttpPost]
        public CommonResponse<GetOrderResponse> FetchOrder([FromBody] GetOrderRequest request)
        {
            return _getOrder.FetchOrder(request);
        }

        [HttpPost]
        public CommonResponse<GetOrderDetailResponse> FetchOrderDetailByID(GetOrderDetailRequest request)
        {
            return _getOrder.FetchOrderDetailByID(request);
        }
    }
}
 