using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Setup.Request.Admin.brand
{
    public class BrandUpdateRequest
    {
        [Required(ErrorMessage = "Brand Id Required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Brand Name required")]
        public string? Name { get; set; }

        public int? Status {  get; set; }

        public IFormFile? Image { get; set; }
    }
    public class BrandUpdateResponse { }
}
