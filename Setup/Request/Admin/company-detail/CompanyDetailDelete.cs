using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.company_detail
{
    #region Request Class
    public class CompanyDetailDeleteRequest
    {
        [Required(ErrorMessage = "Company Detail ID Required")]
        public int ID { get; set; }
    }
    #endregion

    #region Response Class
    public class CompanyDetailDeleteResponse 
    { 
    }
    #endregion
}
