using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.BL.Admin.brand;

using Setup.DAL;
using Setup.ITF.Admin.brand;
using Setup.Request.Admin.brand;


namespace ZordikWebApi.Controllers.Admin.brand
{
    [Route("api/[action]")]
    [ApiController]
    public class DeleteBrandAPIController : ControllerBase
    {
        private readonly IBrandDelete _brandDelete;

        public DeleteBrandAPIController(IBrandDelete brandDelete)
        {
            _brandDelete = brandDelete;
        }

        [HttpPost]
        public CommonResponse<BrandDeleteResponse> DeleteBrand(BrandDeleteRequest objRequest)
        {
            return _brandDelete.DeleteBrand(objRequest);
        }

    }
}
