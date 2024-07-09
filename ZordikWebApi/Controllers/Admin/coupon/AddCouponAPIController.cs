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
    public class AddCouponAPIController : ControllerBase
    {
        private readonly IAddCoupon _addCoupon;

        public AddCouponAPIController(IAddCoupon addCoupon)
        {
            _addCoupon = addCoupon;
        }

        [HttpPost]
        public CommonResponse<AddCouponResponse> InsertCoupon([FromForm] AddCouponRequest objRequest)
        {
            return _addCoupon.InsertCoupon(objRequest);
        }
    }
}
