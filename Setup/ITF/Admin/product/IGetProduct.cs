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
    public interface IGetProduct
    {
        #region Fetch Product Interface
        CommonResponse<GetProductResponse> FetchProduct(GetProductRequest objRequest);
        #endregion

        #region Fetch Product images By Id Interface
        CommonResponse<GetProductByIdResponse> FetchProductImageById(GetProductByIdRequest objRequest);
        #endregion
    }
}
