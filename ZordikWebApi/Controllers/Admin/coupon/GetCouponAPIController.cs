using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.coupon;
using Setup.ITF.Admin.order;
using Setup.Request.Admin.coupon;
using Setup.Request.Admin.order;

namespace ZordikWebApi.Controllers.Admin.coupon
{
    [Route("api/[action]")]
    [ApiController]
    public class GetCouponAPIController : ControllerBase
    {
        private readonly IGetCoupon _getCoupon;

        public GetCouponAPIController(IGetCoupon getCoupon)
        {
            _getCoupon = getCoupon;
        }

        [HttpPost]
        public CommonResponse<GetCouponResponse> FetchCoupon([FromBody] GetCouponRequest request)
        {
            return _getCoupon.FetchCoupon(request);
        }
    }
}
