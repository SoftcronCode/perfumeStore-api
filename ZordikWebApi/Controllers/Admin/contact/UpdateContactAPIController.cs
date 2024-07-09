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
    public class UpdateContactAPIController : ControllerBase
    {
        private readonly IContactUpdate _contactUpdate;

        public UpdateContactAPIController(IContactUpdate contactUpdate)
        {
            _contactUpdate = contactUpdate;
        }

        [HttpPost]
        public CommonResponse<ContactUpdateResponse> UpdateContact([FromBody] ContactUpdateRequest objRequest)
        {
            return _contactUpdate.UpdateContact(objRequest);
        }
    }
}
