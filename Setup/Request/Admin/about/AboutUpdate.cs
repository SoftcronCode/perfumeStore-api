using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.about
{
    public class AboutUpdateRequest
    {
        [Required(ErrorMessage = "About_ID Required.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "About Title 1 is Required.")]
        public string? AboutTitle1 { get; set; }

        [Required(ErrorMessage = "About Description 1 is Required.")]
        public string? AboutDescription1 { get; set; }


        [Required(ErrorMessage = "About Title 2 is Required.")]
        public string? AboutTitle2 { get; set; }

        [Required(ErrorMessage = "About Description 2 is Required.")]
        public string? AboutDescription2 { get; set; }

        [Required(ErrorMessage = "About Title 3 is Required.")]
        public string? AboutTitle3 { get; set; }

        [Required(ErrorMessage = "About Description 3 is Required.")]
        public string? AboutDescription3 { get; set; }

        [Required(ErrorMessage = "Meta Description is Required.")]
        public string? MetaDescription { get; set; }

        [Required(ErrorMessage = "Meta Key is Required.")]
        public string? MetaKey { get; set; }

        public int Status { get; set; }


        public IFormFile? Image { get; set; }

    }
    public class AboutUpdateResponse
    {

    }
}
