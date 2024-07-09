using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.ITF.Admin.product.ToggleProductFeature;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.ToggleProductFeature;

namespace ZordikWebApi.Controllers.Admin.product.ToggleProductFeature
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateSingleToggleAPIController : ControllerBase
    {
        private readonly ISingleToggleUpdate _singleToggleUpdate;

        public UpdateSingleToggleAPIController(ISingleToggleUpdate singleToggleUpdate)
        {
            _singleToggleUpdate = singleToggleUpdate;
        }

        [HttpPost]
        public CommonResponse<UpdateSingleToggleResponse> UpdateSingleToggle([FromBody] UpdateSingleToggleRequest objRequest)
        {
            return _singleToggleUpdate.UpdateSingleToggle(objRequest);
        }
    }
}
