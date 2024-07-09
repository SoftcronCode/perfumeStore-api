using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.brand;
using Setup.Request.Admin.brand;


namespace ZordikWebApi.Controllers.Admin.brand
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateBrandAPIController : ControllerBase
    {
        private readonly IBrandUpdate _brandUpdate;

        public UpdateBrandAPIController(IBrandUpdate brandUpdate)
        {
            _brandUpdate = brandUpdate;
        }
        [HttpPost]
        public CommonResponse<BrandUpdateResponse> UpdateBrand([FromForm] BrandUpdateRequest objRequest)
        {
            return _brandUpdate.UpdateBrand(objRequest);
        }
    }
}
