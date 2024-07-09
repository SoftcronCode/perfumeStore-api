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
    public class UpdateSubCategoryAPIController : ControllerBase
    {
        private readonly ISubCategoryUpdate _subCategoryUpdate;

        public UpdateSubCategoryAPIController(ISubCategoryUpdate subCategoryUpdate)
        {
            _subCategoryUpdate = subCategoryUpdate;
        }

        [HttpPost]
        public CommonResponse<SubCategoryUpdateResponse> UpdateSubCategory(SubCategoryUpdateRequest request)
        {
            return _subCategoryUpdate.UpdateSubCategory(request);
        }
    }
}
