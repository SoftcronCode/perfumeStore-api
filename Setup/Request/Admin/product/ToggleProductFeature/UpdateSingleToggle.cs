﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.ToggleProductFeature
{
    #region Request Class
    public class UpdateSingleToggleRequest
    {
        [Required(ErrorMessage = "Id Required.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Status Value Required.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Table Name Required.")]
        public string? ColumnName { get; set; }
    }
    #endregion

    #region Response Class
    public class UpdateSingleToggleResponse
    { }
    #endregion
}
