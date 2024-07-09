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
    public class DeleteContactAPIController : ControllerBase
    {
        private readonly IContactDelete _contactDelete;

        public DeleteContactAPIController(IContactDelete contactDelete)
        {
            _contactDelete = contactDelete;
        }

        [HttpPost]
        public CommonResponse<ContactDeleteResponse> DeleteContact([FromBody] ContactDeleteRequest objRequest)
        {
            return _contactDelete.DeleteContact(objRequest);
        }
    }
}
