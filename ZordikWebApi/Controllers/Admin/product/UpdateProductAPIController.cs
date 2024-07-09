using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.category;
using Setup.Request.Admin.product;
using Setup.Response.Admin.category;

namespace ZordikWebApi.Controllers.Admin.product
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateProductAPIController : ControllerBase
    {
        private readonly IProductUpdate _productUpdate;

        public UpdateProductAPIController(IProductUpdate categoryUpdate)
        {
            _productUpdate = categoryUpdate;
        }

        [HttpPost]
        public CommonResponse<ProductUpdateResponse> UpdateProduct([FromForm] ProductUpdateRequest objRequest)
        {
            return _productUpdate.UpdateProduct(objRequest);
        }
    }
}
