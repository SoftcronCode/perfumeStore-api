using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.auth;
using Setup.Request.Admin.auth;
using Setup.Response.Admin.auth;

namespace ZordikWebApi.Controllers.Admin.auth
{
    [Route("api/[action]")]
    [ApiController]

    public class AdminLoginAPIController : ControllerBase
    {
        private readonly IAdminLogin _adminLogin;

        public AdminLoginAPIController(IAdminLogin adminLogin)
        {
            _adminLogin = adminLogin;
        }

        [HttpPost]
        public CommonResponse<AdminLoginResponse> AdminSignIn ([FromBody] AdminLoginRequest objRequest)
        {
            return _adminLogin.AdminSignIn(objRequest);
        }
    }
}
