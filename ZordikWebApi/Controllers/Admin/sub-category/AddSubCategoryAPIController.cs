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
    public class AddSubCategoryAPIController : ControllerBase
    {
        private readonly IAddSubCategory _addSubCategory;

        public AddSubCategoryAPIController(IAddSubCategory addSubCategory)
        {
            _addSubCategory = addSubCategory;
        }

        [HttpPost]
        public CommonResponse<AddSubCategoryResponse> InsertSubCategory([FromBody] AddSubCategoryRequest request)
        {
            return _addSubCategory.InsertSubCategory(request);
        }
    }
}
