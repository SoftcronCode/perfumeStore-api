using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.auth;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.auth;
using Setup.Request.Admin.product;

namespace ZordikWebApi.Controllers.Admin.auth
{
    [Route("api/[action]")]
    [ApiController]
    public class ForgotPasswordAPIController : ControllerBase
    {
        private readonly IForgotPassword _forgotPassword;

        public ForgotPasswordAPIController(IForgotPassword forgotPassword)
        {
            _forgotPassword = forgotPassword;
        }

        [HttpPost]
        public CommonResponse<ForgotPasswordResponse> ForgotAdminPassword([FromBody] ForgotPasswordRequest objRequest)
        {
            return _forgotPassword.ForgotAdminPassword(objRequest);
        }
    }
}
