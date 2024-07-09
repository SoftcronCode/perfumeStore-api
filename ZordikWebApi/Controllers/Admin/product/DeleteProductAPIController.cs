using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.product;

namespace ZordikWebApi.Controllers.Admin.product
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteProductAPIController : ControllerBase
    {
        private readonly IProductDelete _productDelete;

        public DeleteProductAPIController(IProductDelete productDelete)
        {
            _productDelete = productDelete;
        }

        [HttpPost]
        public CommonResponse<ProductDeleteResponse> DeleteProduct([FromBody] ProductDeleteRequest objRequest)
        {
            return _productDelete.DeleteProduct(objRequest);
        }
    }
}
