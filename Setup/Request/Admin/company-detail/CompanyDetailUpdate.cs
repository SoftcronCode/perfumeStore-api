using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.company_detail
{
    #region Request Class
    public class CompanyDetailUpdateRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Email is Required. ")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Address is Required.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "{Phone is Required.")]
        public string? address { get; set; }

        [Required(ErrorMessage = "{Name is Required.")]
        public string? phone { get; set; }

        public IFormFile? Company_logo { get; set; }

        [Required(ErrorMessage = "{Name is Required.")]
        public string? google_link { get; set; }

        [Required(ErrorMessage = "{Name is Required.")]
        public string? instagram_link { get; set; }

        [Required(ErrorMessage = "{Name is Required.")]
        public string? facebook_link { get; set; }

        [Required(ErrorMessage = "{Name is Required.")]
        public string? twitter_link { get; set; }

        [Required(ErrorMessage = "{Name is Required.")]
        public string? youtube_link { get; set; }

        public int? status { get; set; }
    }
    #endregion

    #region Request Class
    public class CompanyDetailUpdateResponse 
    { 
    }
    #endregion
}
