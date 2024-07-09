using Setup.DAL;
using Setup.Request.Admin.category;
using Setup.Request.Admin.contact;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.contact
{
    public interface IContactUpdate
    {
        CommonResponse<ContactUpdateResponse> UpdateContact(ContactUpdateRequest objRequest);
    }
}
