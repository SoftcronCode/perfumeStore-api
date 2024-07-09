using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.brand;
using Setup.Request.Admin.brand;


namespace ZordikWebApi.Controllers.Admin.brand
{
    [Route("api/[action]")]
    [ApiController]
    public class AddBrandAPIController : ControllerBase
    {
        private readonly IAddBrand _addBrand;

        public AddBrandAPIController(IAddBrand addBrand)
        {
            _addBrand = addBrand;
        }

        [HttpPost]
        public CommonResponse<AddBrandResponse> InsertBrand([FromForm] AddBrandRequest objRequest)
        {
            return _addBrand.InsertBrand(objRequest);
        }
    }
}
