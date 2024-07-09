using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.common
{
    public class RecordDeleteRequest
    {
        [Required (ErrorMessage = "ID is Required")]
        public int PrimaryId { get; set; }

        [Required(ErrorMessage = "TableName is Required")]
        public string? TableName { get; set; }

    }
}
