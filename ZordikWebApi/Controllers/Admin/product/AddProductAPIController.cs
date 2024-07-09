using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.product;

namespace ZordikWebApi.Controllers.Admin.product
{
    [Route("api/[action]")]
    [ApiController]
    public class AddProductAPIController : ControllerBase
    {
        private readonly IAddProduct _addProduct;

        public AddProductAPIController(IAddProduct addProduct)
        {
            _addProduct = addProduct;
        }

        [HttpPost]
        public CommonResponse<AddProductResponse> InsertProduct([FromForm] AddProductRequest objRequest)
        {
            return _addProduct.InsertProduct(objRequest);
        }
    }
}
