using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.auth
{
    #region Request Class
    public class UpdatePasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
    #endregion

    #region Response Class
    public class UpdatePasswordResponse
    {
    }
    #endregion
}
