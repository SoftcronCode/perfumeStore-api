using Setup.DAL;
using Setup.Request.Admin.company_detail;


namespace Setup.ITF.Admin.company_detail
{
    public interface IGetCompanyDetail
    {
        CommonResponse<GetCompanyDetailResponse> FetchCompanyDetail(GetCompanyDetailRequest objRequest);
    }
}
