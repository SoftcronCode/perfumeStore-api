using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.sub_category
{
    public class SubCategoryDeleteRequest
    {
        [Required(ErrorMessage = "ID Required")]
        public int SubCategory_id { get; set; }
    }
}
