using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.ITF.Admin.product.product_image;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.product_image;

namespace ZordikWebApi.Controllers.Admin.product.product_image
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteProductImageAPIController : ControllerBase
    {
        private readonly IProductImageDelete _productImageDelete;

        public DeleteProductImageAPIController(IProductImageDelete productImageDelete)
        {
            _productImageDelete = productImageDelete;
        }

        [HttpPost]
        public CommonResponse<ProductImageDeleteResponse> DeleteProductImage([FromBody] ProductImageDeleteRequest objRequest)
        {
            return _productImageDelete.DeleteProductImage(objRequest);
        }
    }
}
