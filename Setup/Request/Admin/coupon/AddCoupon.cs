using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.coupon
{
    #region Request Class
    public class AddCouponRequest
    {
        [Required(ErrorMessage = "Coupon Name is required")]
        public string? coupon_name { get; set; }

        [Required(ErrorMessage = "Coupon Value is required")]
        public string? coupon_value { get; set; }

        [Required(ErrorMessage = "Coupon Type is required")]
        public string? coupon_type { get; set; }

        [Required(ErrorMessage = "Cart_Min_Value is required")]
        public string? cart_min_value { get; set; }

        [Required(ErrorMessage = "Expiry_Date is required")]
        public string? expiry_date { get; set; }

        [Required(ErrorMessage = "Total_Uses is required")]
        public int? total_uses { get; set; }

        [Required(ErrorMessage = "Remaining_Uses is required")]
        public int? remaining_uses { get; set; }

        [Required(ErrorMessage = "Min_Purchase_Amount is required")]
        public int? min_purchase_amount { get; set; }

        [Required(ErrorMessage = "Usage_Limit is required")]
        public int? usage_limit { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        public int? discount { get; set; }

        public int? Status { get; set; }
    }
    #endregion

    #region response Class
    public class AddCouponResponse
    {
    }
    #endregion
}
