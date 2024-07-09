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
    public class DeleteBlogAPIController : ControllerBase
    {
        private readonly IBlogDelete _blogDelete;

        public DeleteBlogAPIController(IBlogDelete blogDelete)
        {
            _blogDelete = blogDelete;
        }

        [HttpPost]
        public CommonResponse<BlogDeleteResponse> DeleteBlog([FromForm] BlogDeleteRequest objRequest)
        {
            return _blogDelete.DeleteBlog(objRequest);
        }
    }
}
