using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.common;
using Setup.ITF.Admin.product.ToggleProductFeature;
using Setup.Request.Admin.common;
using Setup.Request.Admin.product.ToggleProductFeature;
using Setup.Response.Admin.common;

namespace ZordikWebApi.Controllers.Admin.product.ToggleProductFeature
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateBulkToggleAPIController : ControllerBase
    {
        private readonly IBulkToggleUpdate _bulkToggle;

        public UpdateBulkToggleAPIController(IBulkToggleUpdate bulkToggle)
        {
            _bulkToggle = bulkToggle;
        }

        [HttpPut]
        public CommonResponse<UpdateBulkToggleResponse> BulkToggle([FromBody] UpdateBulkToggleRequest objRequest)
        {
            return _bulkToggle.BulkToggle(objRequest);
        }
    }
}
