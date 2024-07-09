using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.color
{
    public class ColorDeleteRequest
    {
        [Required (ErrorMessage = "Color Id Required.")]
        public int ColorId { get; set; }
    }
}
