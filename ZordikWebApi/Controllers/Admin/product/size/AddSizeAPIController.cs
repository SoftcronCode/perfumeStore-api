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
    public class AddSizeAPIController : ControllerBase
    {
        private readonly IAddSize _addSize;

        public AddSizeAPIController(IAddSize addSize)
        {
            _addSize = addSize;
        }

        [HttpPost]
        public CommonResponse<AddSizeResponse> AddNewSize( [FromBody] AddSizeRequest request)
        {
            return _addSize.AddNewSize(request);
        }
    }
}
