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
    public class DeleteSizeAPIController : ControllerBase
    {
        private readonly ISizeDelete _sizeDelete;

        public DeleteSizeAPIController(ISizeDelete sizeDelete)
        {
            _sizeDelete = sizeDelete;
        }

        [HttpPost]
        public CommonResponse<SizeDeleteResponse> DeleteSize([FromBody] SizeDeleteRequest request)
        {
            return _sizeDelete.DeleteSize(request);
        }
    }
}
