using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.ITF.Admin.product.variation;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.variation;

namespace ZordikWebApi.Controllers.Admin.product.variation
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteVariationAPIController : ControllerBase
    {
        private readonly IVariationDelete _variationDelete;

        public DeleteVariationAPIController(IVariationDelete variationDelete)
        {
            _variationDelete = variationDelete;
        }

        [HttpPost]
        public CommonResponse<VariationDeleteResponse> DeleteVariation([FromBody] VariationDeleteRequest objRequest)
        {
            return _variationDelete.DeleteVariation(objRequest);
        }
    }
}
