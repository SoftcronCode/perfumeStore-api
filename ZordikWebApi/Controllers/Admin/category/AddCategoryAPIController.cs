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
    public class AddCategoryAPIController : ControllerBase
    {
        private readonly IAddCategory _addCategory;

        public AddCategoryAPIController(IAddCategory addCategory)
        {
            _addCategory = addCategory;
        }

        [HttpPost]
        public CommonResponse<AddCategoryResponse> InsertCategory([FromForm] AddCategoryRequest objRequest)
        {
            return _addCategory.InsertCategory(objRequest);
        }
    }
}
