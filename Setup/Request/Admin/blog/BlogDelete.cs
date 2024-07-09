using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.blog
{
    #region Request Class
    public class BlogDeleteRequest
    {
        [Required(ErrorMessage = "Blog ID Required")]
        public int ID { get; set; }
    }
    #endregion

    #region Response Class
    public class BlogDeleteResponse
    {
    }
    #endregion
}
