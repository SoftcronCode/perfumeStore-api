using Setup.DAL;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.product_image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.product.product_image
{
    public interface IProductImageDelete
    {
        CommonResponse<ProductImageDeleteResponse> DeleteProductImage(ProductImageDeleteRequest objRequest);
    }
}
