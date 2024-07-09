using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.Admin.product.variation
{
    public class VariationUpdateRequest
    {
        #region Request Class
        public int id { get; set; }
        public int variation_id { get; set; }
        public int size_id { get; set; }
        public int color_id { get; set; }
        public int mrp { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
        public int ImageId { get; set; }
    }
    #endregion

    #region Request Class
    public class VariationUpdateResponse
    {
    }
    #endregion
}
