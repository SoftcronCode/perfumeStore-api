using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.auth
{
    #region Request Class
    public class UpdateUserPasswordRequest
    {
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }
    }
    #endregion

    #region Response Class
    public class UpdateUserPasswordResponse
    {
    }
    #endregion
}
