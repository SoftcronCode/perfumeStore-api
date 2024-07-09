using Setup.DAL;
using Setup.Request.Admin.auth;
using Setup.Request.User.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.auth
{
    public interface IUpdateUserPassword
    {
        CommonResponse<UpdateUserPasswordResponse> UpdateUserPasswords(UpdateUserPasswordRequest objRequest);
    }
}
