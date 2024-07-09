using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.order
{
    #region Request Class
    public class OrderUpdateRequest
    {
        [Required(ErrorMessage = "Order Id Required.")]
        public int orderID { get; set; }

        [Required(ErrorMessage = "Status Id Required.")]
        public int orderStatusID { get; set; }

        public string? trackingID { get; set; }

        public String? courierName { get; set; }

        public String? reason { get; set; }
    }
    #endregion

    #region Response Class
    public class OrderUpdateResponse
    {
    }
    #endregion
}
