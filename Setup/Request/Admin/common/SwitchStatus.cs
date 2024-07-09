using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.common
{
    public class SwitchStatusRequest
    {
        [Required (ErrorMessage = "Id Required.")]
        public int ID { get; set; }

        [Required (ErrorMessage = "Status Value Required.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Table Name Required.")]
        public string? TableName { get; set; }
    }
}
