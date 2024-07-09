using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.contact;
using Setup.Request.Admin.contact;

namespace ZordikWebApi.Controllers.Admin.contact
{
    [Route("api/[action]")]
    [ApiController]
    public class AddContactAPIController : ControllerBase
    {
        private readonly IAddContact _addContact;

        public AddContactAPIController(IAddContact addContact)
        {
            _addContact = addContact;
        }
        [HttpPost]
        public CommonResponse<AddContactResponse> InsertContact([FromBody] AddContactRequest objRequest)
        {
            return _addContact.InsertContact(objRequest);
        }
    }
}
