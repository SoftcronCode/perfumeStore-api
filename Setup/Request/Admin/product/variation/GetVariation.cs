using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.variation
{
    #region Request Class
    public class GetVariationRequest
    {
        [Required(ErrorMessage = "Product Id Required.")]
        public int ProductId { get; set; }
    }
    #endregion

    #region Response Class
    public class GetVariationResponse
    {
    }
    #endregion
}
