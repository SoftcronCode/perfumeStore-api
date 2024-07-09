using Setup.DAL;
using Setup.Request.Admin.category;
using Setup.Request.Admin.contact;
using Setup.Response.Admin.category;


namespace Setup.ITF.Admin.contact
{
     public interface IAddContact
    {
        CommonResponse<AddContactResponse> InsertContact(AddContactRequest objRequest);
    }
}
