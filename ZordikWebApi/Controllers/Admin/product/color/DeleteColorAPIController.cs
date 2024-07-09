using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product.color;
using Setup.Request.Admin.product.color;
using Setup.Response.Admin.product.color;

namespace ZordikWebApi.Controllers.Admin.product.color
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteColorAPIController : ControllerBase
    {
        private readonly IColorDelete _colorDelete;

        public DeleteColorAPIController (IColorDelete colorDelete)
        {
            _colorDelete = colorDelete;
        }

        [HttpPost]
        public CommonResponse<ColorDeleteResponse> DeleteColor([FromBody] ColorDeleteRequest request)
        {
            return _colorDelete.DeleteColor(request);
        }
    }
}
