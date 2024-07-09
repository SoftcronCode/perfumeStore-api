using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.product;

namespace ZordikWebApi.Controllers.Admin.product
{
    [Route("api/[action]")]
    [ApiController]
    public class GetProductAPIController : ControllerBase
    {
        private readonly IGetProduct _getProduct;

        public GetProductAPIController(IGetProduct product)
        {
            _getProduct = product;
        }

        #region Fetch Product Method
        [HttpPost]
        public CommonResponse<GetProductResponse> FetchProduct([FromBody] GetProductRequest ObjRequest)
        {
            return _getProduct.FetchProduct(ObjRequest);
        }
        #endregion

        #region Fetch Product images By Id Method
        [HttpPost]
        public CommonResponse<GetProductByIdResponse> FetchProductImageById([FromBody] GetProductByIdRequest ObjRequest)
        {
            return _getProduct.FetchProductImageById(ObjRequest);
        }
        #endregion
    }
}
