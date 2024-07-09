using Setup.DAL;
using Setup.Request.Admin.coupon;
using Setup.Request.Admin.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.coupon
{
    public interface IAddCoupon
    {
        CommonResponse<AddCouponResponse> InsertCoupon(AddCouponRequest objRequest);
    }
}
