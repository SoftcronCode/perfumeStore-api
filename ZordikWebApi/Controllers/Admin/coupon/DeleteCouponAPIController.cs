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
    public class DeleteCouponAPIController : ControllerBase
    {
        private readonly ICouponDelete _couponDelete;

        public DeleteCouponAPIController(ICouponDelete couponDelete)
        {
            _couponDelete = couponDelete;
        }

        [HttpPost]
        public CommonResponse<CouponDeleteResponse> DeleteCoupon([FromBody] CouponDeleteRequest request)
        {
            return _couponDelete.DeleteCoupon(request);
        }
    }
}
