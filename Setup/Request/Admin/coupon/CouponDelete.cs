using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.coupon
{
    #region Request Class
    public class CouponDeleteRequest
    {
        [Required(ErrorMessage = "Coupon ID Required")]
        public int ID { get; set; }
    }
    #endregion

    #region Response Class
    public class CouponDeleteResponse
    {
    }
    #endregion
}
