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
    public class UpdateCouponAPIController : ControllerBase
    {
        private readonly ICouponUpdate _couponUpdate;

        public UpdateCouponAPIController(ICouponUpdate couponUpdate)
        {
            _couponUpdate = couponUpdate;
        }

        [HttpPost]
        public CommonResponse<UpdateCouponResponse> UpdateCoupon(CouponUpdateRequest request)
        {
            return _couponUpdate.UpdateCoupon(request);
        }
    }
}
