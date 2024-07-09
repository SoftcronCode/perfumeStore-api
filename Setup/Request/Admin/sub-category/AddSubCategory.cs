using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.sub_category
{
    public class AddSubCategoryRequest
    {
        [Required(ErrorMessage = "Category ID Required.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Slug is Required.")]
        public string? Slug { get; set; }

        public int Status { get; set; }
    }
}
