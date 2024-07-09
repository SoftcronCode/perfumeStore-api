using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.about;
using Setup.ITF.Admin.category;
using Setup.Request.Admin.about;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;

namespace ZordikWebApi.Controllers.Admin.about
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteAboutAPIController : ControllerBase
    {
        private readonly IAboutDelete _aboutDelete;

        public DeleteAboutAPIController(IAboutDelete aboutDelete)
        {
            _aboutDelete = aboutDelete;
        }

        [HttpPost]
        public CommonResponse<AboutDeleteResponse> DeleteAbout(AboutDeleteRequest objRequest)
        {
            return _aboutDelete.DeleteAbout(objRequest);
        }
    }
}
