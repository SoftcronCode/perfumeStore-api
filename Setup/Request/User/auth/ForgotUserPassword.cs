using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.auth
{
    #region Request Class
    public class ForgotUserPasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
    }
    #endregion


    #region Response Class
    public class ForgotUserPasswordResponse
    {
        public string? OTP { get; set; }
    }
    #endregion
}
