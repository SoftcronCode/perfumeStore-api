using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.auth;
using Setup.ITF.User.auth;
using Setup.Request.Admin.auth;
using Setup.Request.User.auth;

namespace ZordikWebApi.Controllers.User.auth
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateUserPasswordAPIController : ControllerBase
    {
        private readonly IUpdateUserPassword _updateUserPassword;

        public UpdateUserPasswordAPIController(IUpdateUserPassword updateUserPassword)
        {
            _updateUserPassword = updateUserPassword;
        }

        [HttpPost]
        public CommonResponse<UpdateUserPasswordResponse> UpdateUserPasswords([FromForm] UpdateUserPasswordRequest objRequest)
        {
            return _updateUserPassword.UpdateUserPasswords(objRequest);
        }
    }
}
