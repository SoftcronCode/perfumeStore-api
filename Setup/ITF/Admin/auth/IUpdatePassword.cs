using Setup.DAL;
using Setup.Request.Admin.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.auth
{
    public interface IUpdatePassword
    {
        CommonResponse<UpdatePasswordResponse> UpdateAdminPassword(UpdatePasswordRequest objRequest);
    }
}
