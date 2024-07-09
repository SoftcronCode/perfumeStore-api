using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.order
{
    public class OrderStatusRequest
    {
        [Required (ErrorMessage = "Order Id required !")]
        public int OrderId { get; set; }

        [Required (ErrorMessage = "Status ID Required !")]
        public int StatusId { get; set; }
    }
}
