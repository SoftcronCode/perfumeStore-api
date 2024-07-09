using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.blog;
using Setup.Request.Admin.blog;

namespace ZordikWebApi.Controllers.Admin.blog
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateBlogAPIController : ControllerBase
    {
        private readonly IBlogUpdate _updateBlog;

        public UpdateBlogAPIController(IBlogUpdate updateBlogCategory)
        {
            _updateBlog = updateBlogCategory;
        }

        [HttpPost]
        public CommonResponse<BlogUpdateResponse> UpdateBlog([FromBody] BlogUpdateRequest objRequest)
        {
            return _updateBlog.UpdateBlog(objRequest);
        }
    }
}
