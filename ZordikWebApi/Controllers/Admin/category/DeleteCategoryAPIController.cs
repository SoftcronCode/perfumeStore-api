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
    public class DeleteCategoryAPIController : ControllerBase
    {
        private readonly ICategoryDelete _categoryDelete;

        public DeleteCategoryAPIController(ICategoryDelete categoryDelete)
        {
            _categoryDelete = categoryDelete;
        }

        [HttpPost]
        public CommonResponse<CategoryDeleteResponse> DeleteCategory(CategoryDeleteRequest objRequest)
        {
            return _categoryDelete.DeleteCategory(objRequest);
        }
    }
}
