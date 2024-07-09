using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.auth;
using Setup.Request.Admin.auth;

namespace ZordikWebApi.Controllers.Admin.auth
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdatePasswordAPIController : ControllerBase
    {
        private readonly IUpdatePassword _updatePassword;

        public UpdatePasswordAPIController(IUpdatePassword updatePassword)
        {
            _updatePassword = updatePassword;
        }

        [HttpPost]
        public CommonResponse<UpdatePasswordResponse> UpdateAdminPassword([FromBody] UpdatePasswordRequest objRequest)
        {
            return _updatePassword.UpdateAdminPassword(objRequest);
        }
    }
}
