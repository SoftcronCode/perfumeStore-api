using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.Admin.company_detail;
using Setup.ITF.Admin.contact;
using Setup.Request.Admin.company_detail;
using Setup.Request.Admin.contact;

namespace ZordikWebApi.Controllers.Admin.company_detail
{
    [Route("api/[action]")]
    [ApiController]
    public class AddCompanyDetailAPIController : ControllerBase
    {
        private readonly IAddCompanyDetail _addCompanyDetail;

        public AddCompanyDetailAPIController(IAddCompanyDetail addCompanyDetail)
        {
            _addCompanyDetail = addCompanyDetail;
        }
        [HttpPost]
        public CommonResponse<AddCompanyDetailResponse> InsertCompanyDetail([FromForm] AddCompanyDetailRequest objRequest)
        {
            return _addCompanyDetail.InsertCompanyDetail(objRequest);
        }
    }
}
