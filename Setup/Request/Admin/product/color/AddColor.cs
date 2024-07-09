using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.color
{
    public class AddColorRequest
    {
        [Required(ErrorMessage = "Color Name Is Required.")]
        public string? ColorName { get; set; }

        [Required(ErrorMessage = "Status ID Required.")]
        public int Status { get; set; }
    }
}
