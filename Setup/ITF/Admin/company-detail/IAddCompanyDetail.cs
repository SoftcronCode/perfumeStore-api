using Setup.DAL;
using Setup.Request.Admin.company_detail;

namespace Setup.ITF.Admin.company_detail
{
    public interface IAddCompanyDetail
    {
        CommonResponse<AddCompanyDetailResponse> InsertCompanyDetail(AddCompanyDetailRequest objRequest);

    }
}
