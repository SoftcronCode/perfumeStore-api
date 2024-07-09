using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Setup.Request.Admin.brand
{
    public class AddBrandRequest
    {
        [Required(ErrorMessage = "Brand Name required")]
        public string? Name { get; set; }

        public IFormFile? Image{ get; set; }

        public int? Status {  get; set; }

    }

    public class AddBrandResponse
    {

    }
}
