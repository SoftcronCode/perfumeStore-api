using Setup.DAL;
using Setup.Request.Admin.brand;


namespace Setup.ITF.Admin.brand
{
    public interface IGetBrand 
    {
        CommonResponse<GetBrandResponse> FetchBrand(GetBrandRequest objRequest);

        CommonResponse<GetBrandResponse> FetchActiveBrand(GetBrandRequest objRequest);
    }
}
