using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product.color;
using Setup.RequestL.Admin.product.color;
using Setup.Response.Admin.product.color;

namespace ZordikWebApi.Controllers.Admin.product.color
{
    [Route("api/[action]")]
    [ApiController]
    public class GetColorAPIController : ControllerBase
    {
        private readonly IGetColor _getColor;

        public GetColorAPIController(IGetColor getColor)
        {
            _getColor = getColor;
        }

        [HttpPost]
        public CommonResponse<GetColorResponse> FetchColor( [FromBody] GetColorRequest request)
        {
            return _getColor.FetchColor(request);
        }
    }
}
