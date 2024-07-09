using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.address
{
    public class AddressSelectRequest
    {
        [Required (ErrorMessage = "User Id Required")]
        public int UserId { get; set; }
    }

    public class SelectDefaultAddressRequest
    {
        [Required(ErrorMessage = "User Id Required")]
        public int UserId { get; set; }
    }
}
