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
    public class DeleteSubCategoryAPIController : ControllerBase
    {
        private readonly ISubCategoryDelete _subCategoryDelete;

        public DeleteSubCategoryAPIController(ISubCategoryDelete subCategoryDelete)
        {
            _subCategoryDelete = subCategoryDelete;
        }

        [HttpPost]
        public CommonResponse<SubCategoryDeleteResponse> DeleteSubCategory([FromBody] SubCategoryDeleteRequest request)
        {
            return _subCategoryDelete.DeleteSubCategory(request);
        }
    }
}
