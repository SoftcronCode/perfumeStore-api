using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.BL.Admin.sub_category;
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
    public class AddAboutAPIController : ControllerBase
    {
        private readonly IAddAbout _addAbout;

        public AddAboutAPIController(IAddAbout addAbout)
        {
            _addAbout = addAbout;
        }

        [HttpPost]
        public CommonResponse<AddAboutResponse> InsertAbout([FromForm] AddAboutRequest request)
        {
            return _addAbout.InsertAbout(request);
        }
    }
}
