using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.contact
{
    #region Request Class
    public class AddContactRequest
    {
        [Required(ErrorMessage = "Phone number is Required. ")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        public string? Email { get; set; }        

        [Required(ErrorMessage = "Address is Required.")]
        public string? Address{ get; set; }

        public int? Status { get; set; }

        [Required(ErrorMessage = "Google Map  is Required.")]
        public string? google_map { get; set; } 
    }
    #endregion

    #region Response Class
    public class AddContactResponse 
    { 
    }
    #endregion
}
