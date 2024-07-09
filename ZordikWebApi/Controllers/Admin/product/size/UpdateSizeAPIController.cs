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
    public class UpdateSizeAPIController : ControllerBase
    {
        private readonly ISizeUpdate _sizeUpdate;

        public UpdateSizeAPIController(ISizeUpdate sizeUpdate)
        {
            _sizeUpdate = sizeUpdate;
        }

        [HttpPost]
        public CommonResponse<SizeUpdateResponse> UpdateSize(SizeUpdateRequest request)
        {
            return _sizeUpdate.UpdateSize(request);
        }
    }
}
