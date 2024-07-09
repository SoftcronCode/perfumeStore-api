using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.about;
using Setup.ITF.Admin.sub_category;
using Setup.Request.Admin.about;
using Setup.Request.Admin.sub_category;
using Setup.Response.Admin.sub_category;

namespace ZordikWebApi.Controllers.Admin.about
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateAboutAPIController : ControllerBase
    {
        private readonly IAboutUpdate _aboutUpdate;

        public UpdateAboutAPIController(IAboutUpdate aboutUpdate)
        {
            _aboutUpdate = aboutUpdate;
        }

        [HttpPost]
        public CommonResponse<AboutUpdateResponse> UpdateAbout([FromForm] AboutUpdateRequest request)
        {
            return _aboutUpdate.UpdateAbout(request);
        }
    }
}
