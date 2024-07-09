using Setup.DAL;
using Setup.Request.Admin.contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.Admin.contact
{
    public interface IContactDelete
    {
        CommonResponse<ContactDeleteResponse> DeleteContact(ContactDeleteRequest objRequest);
    }
}
