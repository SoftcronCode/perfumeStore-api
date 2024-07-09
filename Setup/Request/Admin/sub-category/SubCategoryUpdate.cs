using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.sub_category
{
    public class SubCategoryUpdateRequest
    {
        [Required (ErrorMessage = "Sub-category ID Required.")]
        public int SubCategory_id { get; set; }

        [Required(ErrorMessage = "Category ID Required.")]
        public int Category_id { get; set; }

        [Required(ErrorMessage = "Name Required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Slug Required.")]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "Status ID Required.")]
        public int Status { get; set; }
    }
}
