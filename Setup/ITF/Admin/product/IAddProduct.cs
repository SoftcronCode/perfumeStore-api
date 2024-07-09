using Setup.DAL;
using Setup.Request.Admin.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product
{
    public interface IAddProduct
    {
        CommonResponse<AddProductResponse> InsertProduct(AddProductRequest objRequest);
    }
}
