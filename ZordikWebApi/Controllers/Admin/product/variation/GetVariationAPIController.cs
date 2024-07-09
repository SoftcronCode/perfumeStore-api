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
    public class GetVariationAPIController : ControllerBase
    {
        private readonly IGetVariation _getVariation;

        public GetVariationAPIController(IGetVariation variation)
        {
            _getVariation = variation;
        }

        [HttpPost]
        public CommonResponse<GetVariationResponse> FetchVariation([FromBody] GetVariationRequest ObjRequest)
        {
            return _getVariation.FetchVariation(ObjRequest);
        }
    }
}
