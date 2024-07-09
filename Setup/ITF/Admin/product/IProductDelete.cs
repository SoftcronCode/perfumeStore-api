using Setup.DAL;
using Setup.Request.Admin.category;
using Setup.Request.Admin.product;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product
{
    public interface IProductDelete
    {
        CommonResponse<ProductDeleteResponse> DeleteProduct(ProductDeleteRequest objRequest);
    }
}
