using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.blog;
using Setup.ITF.Admin.company_detail;
using Setup.Request.Admin.blog;
using Setup.Request.Admin.company_detail;

namespace ZordikWebApi.Controllers.Admin.blog
{
    [Route("api/[action]")]
    [ApiController]
    public class GetBlogAPIController : ControllerBase
    {
        private readonly IGetBlog _getBlog;

        public GetBlogAPIController(IGetBlog getBlog)
        {
            _getBlog = getBlog;
        }

        [HttpPost]
        public CommonResponse<GetBlogResponse> FetchBlog([FromBody] GetBlogRequest objRequest)
        {
            return _getBlog.FetchBlog(objRequest);
        }
    }
}
