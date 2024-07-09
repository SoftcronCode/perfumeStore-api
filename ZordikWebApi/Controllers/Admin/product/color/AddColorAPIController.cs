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
    public class AddColorAPIController : ControllerBase
    {
        private readonly IAddColor _addColor;

        public AddColorAPIController(IAddColor addColor)
        {
            _addColor = addColor;
        }

        [HttpPost]
        public CommonResponse<AddColorResponse> AddNewColor( [FromBody] AddColorRequest request)
        {
            return _addColor.AddNewColor(request);
        }
    }
}
