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
    public class UpdateCategoryAPIController : ControllerBase
    {
        private readonly ICategoryUpdate _categoryUpdate;

        public UpdateCategoryAPIController(ICategoryUpdate categoryUpdate)
        {
            _categoryUpdate = categoryUpdate;
        }

        [HttpPost]
        public CommonResponse<CategoryUpdateResponse> UpdateCategory([FromForm] CategoryUpdateRequest objRequest)
        {
            return _categoryUpdate.UpdateCategory(objRequest);
        }
    }
}
