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
    public class DeleteCompanyDetailAPIController : ControllerBase
    {
        private readonly ICompanyDetailDelete _companyDetailDelete;

        public DeleteCompanyDetailAPIController(ICompanyDetailDelete companyDetailDelete)
        {
            _companyDetailDelete = companyDetailDelete;
        }

        [HttpPost]
        public CommonResponse<CompanyDetailDeleteResponse> DeleteCompanyDetail([FromForm] CompanyDetailDeleteRequest objRequest)
        {
            return _companyDetailDelete.DeleteCompanyDetail(objRequest);
        }
    }
}
