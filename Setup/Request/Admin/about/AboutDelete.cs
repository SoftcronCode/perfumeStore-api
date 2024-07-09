using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.about
{
    public class AboutDeleteRequest
    {
        [Required(ErrorMessage = "About ID Required")]
        public int ID { get; set; }

    }
    public class AboutDeleteResponse {
    }
}
