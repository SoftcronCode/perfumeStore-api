using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.category;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;

namespace ZordikWebApi.Controllers.Admin.category
{
    [Route("api/[action]")]
    [ApiController]
    public class GetCategoryAPIController : ControllerBase
    {
        private readonly IGetCategory _getCategory;

        public GetCategoryAPIController(IGetCategory category)
        {
            _getCategory = category;
        }

        [HttpPost]
        public CommonResponse<GetCategoryResponse> FetchCategory([FromBody] GetCategoryRequest ObjRequest)
        {
            return _getCategory.FetchCategory(ObjRequest);
        }
    }
}
