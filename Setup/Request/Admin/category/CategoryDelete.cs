using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.category
{
    public class CategoryDeleteRequest
    {
        [Required (ErrorMessage ="Category ID Required")]
        public int ID { get; set; }
    }

}
