using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.order
{
    #region Request Class
    public class OrderDeleteRequest
    {
        [Required(ErrorMessage = "Order Id Required.")]
        public int OrderId { get; set; }
    }
    #endregion

    #region Response Class
    public class OrderDeleteResponse
    {
    }
    #endregion
}
