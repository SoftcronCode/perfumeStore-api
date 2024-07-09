using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.common;
using Setup.Request.Admin.common;
using Setup.Response.Admin.common;

namespace ZordikWebApi.Controllers.Admin.common
{
    [Route("api/[action]")]
    [ApiController]
    public class SwitchStatusAPIController : ControllerBase
    {
        private readonly ISwitchStatus _switchStatus;

        public SwitchStatusAPIController(ISwitchStatus switchStatus)
        {
            _switchStatus = switchStatus;
        }

        [HttpPost]
        public CommonResponse<SwitchStatusResponse> ToggleStatus([FromBody] SwitchStatusRequest objRequest)
        {
            return _switchStatus.ToggleStatus(objRequest);
        }
    }
}
