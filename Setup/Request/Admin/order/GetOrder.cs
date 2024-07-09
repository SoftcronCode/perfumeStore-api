using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.order
{
    #region Request Class
    public class GetOrderRequest
    {
    }
    #endregion

    #region Response Class
    public class GetOrderResponse
    {
    }
    #endregion


    public class GetOrderDetailRequest
    {
        public int OrderId { get; set; }
    }

    public class GetOrderDetailResponse
    {

    }
}
