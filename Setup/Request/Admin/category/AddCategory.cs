using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.category
{
    public class AddCategoryRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public IFormFile? Image { get; set; }

        public int? Status { get; set; }

    }
}
