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
    public class GetCompanyDetailAPIController : ControllerBase
    {
        private readonly IGetCompanyDetail _getCompanyDetail;

        public GetCompanyDetailAPIController(IGetCompanyDetail getCompanyDetail)
        {
            _getCompanyDetail = getCompanyDetail;
        }

        [HttpPost]
        public CommonResponse<GetCompanyDetailResponse> FetchCompanyDetail([FromForm] GetCompanyDetailRequest objRequest)
        {
            return _getCompanyDetail.FetchCompanyDetail(objRequest);
        }
    }
}
