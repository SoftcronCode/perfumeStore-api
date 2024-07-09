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
    public class UpdateCompanyDetailAPIController : ControllerBase
    {
        private readonly ICompanyDetailUpdate _companyDetailUpdate;

        public UpdateCompanyDetailAPIController(ICompanyDetailUpdate companyDetailUpdate)
        {
            _companyDetailUpdate = companyDetailUpdate;
        }

        [HttpPost]
        public CommonResponse<CompanyDetailUpdateResponse> UpdateCompanyDetail([FromForm] CompanyDetailUpdateRequest objRequest)
        {
            return _companyDetailUpdate.UpdateCompanyDetail(objRequest);
        }
    }
}
