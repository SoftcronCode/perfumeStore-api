using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.variation
{
    public class VariationDeleteRequest
    {
        [Required(ErrorMessage = "Variation ID Required")]
        public int VariationId { get; set; }
    }

    public class VariationDeleteResponse
    {
    }
}
