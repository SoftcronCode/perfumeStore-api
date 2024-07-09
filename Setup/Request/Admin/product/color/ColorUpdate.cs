using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.color
{
    public class ColorUpdateRequest
    {
        [Required (ErrorMessage = "Color Id required.")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Color Name required.")]
        public string? ColorName { get; set; }

        [Required(ErrorMessage = "Status Id required.")]
        public int Status { get; set; }
    }
}
