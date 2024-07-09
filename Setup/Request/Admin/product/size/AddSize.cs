using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.size
{
    public class AddSizeRequest
    {
        [Required (ErrorMessage = "Size Required")]
        public string? Size { get; set; }
        
        [Required (ErrorMessage = "Status Id Required")]
        public int Status { get; set; }
    }
}
