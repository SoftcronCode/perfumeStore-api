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
    public class ForgotUserPasswordAPIController : ControllerBase
    {
        private readonly IForgotUserPassword _forgotPassword;

        public ForgotUserPasswordAPIController(IForgotUserPassword forgotPassword)
        {
            _forgotPassword = forgotPassword;
        }

        [HttpPost]
        public CommonResponse<ForgotUserPasswordResponse> ForgotUserPasswords([FromForm] ForgotUserPasswordRequest objRequest)
        {
            return _forgotPassword.ForgotUserPasswords(objRequest);
        }
    }
}
