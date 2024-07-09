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
    public class UpdateVariationAPIController : ControllerBase
    {
        private readonly IVariationUpdate _variationUpdate;

        public UpdateVariationAPIController(IVariationUpdate variationUpdate)
        {
            _variationUpdate = variationUpdate;
        }

        [HttpPost]
        public CommonResponse<VariationUpdateResponse> UpdateVariation([FromBody] VariationUpdateRequest objRequest)
        {
            return _variationUpdate.UpdateVariation(objRequest);
        }
    }
}
