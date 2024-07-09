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
    public class UpdateColorAPIController : ControllerBase
    {
        private readonly IColorUpdate _colorUpdate;

        public UpdateColorAPIController(IColorUpdate colorUpdate)
        {
            _colorUpdate = colorUpdate;
        }

        [HttpPost]
        public CommonResponse<ColorUpdateResponse> UpdateColor( [FromBody] ColorUpdateRequest request)
        {
            return _colorUpdate.UpdateColor(request);
        }
    }
}
