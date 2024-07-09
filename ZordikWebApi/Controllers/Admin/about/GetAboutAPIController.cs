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
    public class GetAboutAPIController : ControllerBase
    {
        private readonly IGetAbout _getAbout;

        public GetAboutAPIController(IGetAbout getAbout)
        {
            _getAbout = getAbout;
        }

        [HttpPost]
        public CommonResponse<GetAboutResponse> FetchAbout([FromForm] GetAboutRequest request)
        {
            return _getAbout.FetchAbout(request);
        }
    }
}
