using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.size
{
    public class SizeDeleteRequest
    {
        [Required (ErrorMessage = "Size Id Required.")]
        public int SizeId { get; set; }
    }
}
