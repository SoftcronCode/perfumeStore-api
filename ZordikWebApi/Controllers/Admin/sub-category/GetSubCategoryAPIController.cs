using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.sub_category;
using Setup.Request.Admin.sub_category;
using Setup.Response.Admin.sub_category;

namespace ZordikWebApi.Controllers.Admin.sub_category
{
    [Route("api/[action]")]
    [ApiController]
    public class GetSubCategoryAPIController : ControllerBase
    {
        private readonly IGetSubCategory _getSubCategory;

        public GetSubCategoryAPIController(IGetSubCategory getSubCategory)
        {
            _getSubCategory = getSubCategory;
        }

        [HttpPost]
        public CommonResponse<GetSubCategoryResponse> FetchSubCategories([FromBody] GetSubCategoryRequest request)
        {
              return _getSubCategory.FetchSubCategories(request);
        }

        [HttpPost]
        public CommonResponse<GetSubCategoryResponse> FetchActiveSubCategories([FromBody] GetSubCategoryRequest request)
        {
            return _getSubCategory.FetchActiveSubCategories(request);
        }
    }
}
