using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.blog;
using Setup.Request.Admin.blog;

namespace ZordikWebApi.Controllers.Admin.blog
{
    [Route("api/[action]")]
    [ApiController]
    public class AddBlogAPIController : ControllerBase
    {
        private readonly IAddBlog _addBlog;

        public AddBlogAPIController(IAddBlog addBlog)
        {
            _addBlog = addBlog;
        }
        [HttpPost]
        public CommonResponse<AddBlogResponse> InsertBlog([FromForm] AddBlogRequest objRequest)
        {
            return _addBlog.InsertBlog(objRequest);
        }
    }
}
