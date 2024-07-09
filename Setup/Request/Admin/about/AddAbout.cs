using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.about
{
    public class AddAboutRequest
    {
        [Required(ErrorMessage = "About Title1 is Required.")]
        public string? AboutTitle1 { get; set; }

        [Required(ErrorMessage = "About Title2 is Required.")]
        public string? AboutTitle2 { get; set; }

        [Required(ErrorMessage = "About Title3 is Required.")]
        public string? AboutTitle3 { get; set; }

        [Required(ErrorMessage = "About Description1 is Required.")]
        public string? AboutDescription1 { get; set; }

        [Required(ErrorMessage = "About Description2 is Required.")]
        public string? AboutDescription2 { get; set; }

        [Required(ErrorMessage = "About Description3 is Required.")]
        public string? AboutDescription3 { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Meta description is Required.")]
        public string? MetaDescription { get; set; }

        [Required(ErrorMessage = "Meta key is Required.")]
        public string? MetaKey { get; set; }

        public int Status { get; set; }
    }

    public class AddAboutResponse
    {

    }
}
