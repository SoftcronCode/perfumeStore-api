using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.product.size;
using Setup.Request.Admin.product.size;
using Setup.Response.Admin.product.size;

namespace ZordikWebApi.Controllers.Admin.product.size
{
    [Route("api/[action]")]
    [ApiController]
    public class GetSizeAPIController : ControllerBase
    {
        private readonly IGetSize _getSize;

        public GetSizeAPIController(IGetSize getSize)
        {
            _getSize = getSize;
        }

        [HttpPost]
        public CommonResponse<GetSizeResponse> FetchSize( [FromBody] GetSizeRequest request)
        {
            return _getSize.FetchSize(request);
        }
    }
}
