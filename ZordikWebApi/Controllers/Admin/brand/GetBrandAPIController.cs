using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.brand;
using Setup.Request.Admin.brand;


namespace ZordikWebApi.Controllers.Admin.brand
{
    [Route("api/[action]")]
    [ApiController]
    public class GetBrandAPIController : ControllerBase
    {
        private readonly IGetBrand _getBrand;

        public GetBrandAPIController(IGetBrand brand)
        {
            _getBrand = brand;
        }

        [HttpPost]
        public CommonResponse<GetBrandResponse> FetchBrand([FromBody] GetBrandRequest ObjRequest)
        {
            return _getBrand.FetchBrand(ObjRequest);
        }

        [HttpPost]
        public CommonResponse<GetBrandResponse> FetchActiveBrand([FromBody] GetBrandRequest ObjRequest)
        {
            return _getBrand.FetchActiveBrand(ObjRequest);
        }
    }

}
