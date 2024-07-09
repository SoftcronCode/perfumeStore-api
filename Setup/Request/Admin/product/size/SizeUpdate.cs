using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.size
{
    public class SizeUpdateRequest
    {
        [Required(ErrorMessage = "Size Id required.")]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "Size required.")]
        public string? Size { get; set; }

        [Required(ErrorMessage = "Status Id required.")]
        public int Status { get; set; }
    }
}
