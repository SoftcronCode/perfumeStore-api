using Setup.DAL;
using Setup.Request.Admin.auth;
using Setup.Request.User.auth;
using Setup.Response.Admin.auth;
using Setup.Response.User.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.auth
{
    public interface IAdminLogin
    {
        CommonResponse<AdminLoginResponse> AdminSignIn(AdminLoginRequest objRequest);
    }
}
