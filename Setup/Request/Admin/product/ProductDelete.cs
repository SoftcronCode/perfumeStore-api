using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product
{
    public class ProductDeleteRequest
    {
        [Required(ErrorMessage = "Product ID Required")]
        public int ProductId { get; set; }
    }

    public class ProductDeleteResponse
    {
    }
}
