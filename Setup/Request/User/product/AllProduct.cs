using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.product
{
    public class AllProductRequest
    {
        public int Limit { get; set; }

        public List<int>? Categories { get; set; }

        public List<int>? Subcategories { get; set; }

        public List<int>? Colors { get; set; }

        public List<int>? Sizes { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}
