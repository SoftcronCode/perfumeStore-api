using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.category;
using Setup.ITF.Admin.contact;
using Setup.Request.Admin.category;
using Setup.Request.Admin.contact;
using Setup.Response.Admin.category;

namespace ZordikWebApi.Controllers.Admin.contact
{
    [Route("api/[action]")]
    [ApiController]
    public class GetContactAPIController : ControllerBase
    {
        private readonly IGetContact _getContact;

        public GetContactAPIController(IGetContact getContact)
        {
            _getContact = getContact;
        }

        [HttpPost]
        public CommonResponse<GetContactResponse> FetchContact([FromBody] GetContactRequest objRequest)
        {
            return _getContact.FetchContact(objRequest);
        }
    }
}
