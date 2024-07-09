using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.ToggleProductFeature
{
    #region Request Class
    public class UpdateBulkToggleRequest
    {
        [Required(ErrorMessage = "Id required.")]
        public int[]? ID { get; set; }

        [Required(ErrorMessage = "ColumnName required.")]
        public string[]? ColumnName { get; set; }

        [Required(ErrorMessage = "Status required.")]
        public int Status { get; set; }
    }
    #endregion

    #region Response Class
    public class UpdateBulkToggleResponse
    {
    }
    #endregion
}
