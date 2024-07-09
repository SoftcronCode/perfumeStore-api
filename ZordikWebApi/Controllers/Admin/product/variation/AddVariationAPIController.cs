using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product.variation;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.variation;

namespace ZordikWebApi.Controllers.Admin.product.variation
{
    [Route("api/[action]")]
    [ApiController]
    public class AddVariationAPIController : ControllerBase
    {
        private readonly IAddVariation _addVariation;

        public AddVariationAPIController(IAddVariation addVariation)
        {
            _addVariation = addVariation;
        }

        [HttpPost]
        public CommonResponse<AddVariationResponse> InsertVariation([FromBody] AddVariationRequest objRequest)
        {
            return _addVariation.InsertVariation(objRequest);
        }
    }
}
