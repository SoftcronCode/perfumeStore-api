using Setup.DAL;
using Setup.Request.Admin.brand;


namespace Setup.ITF.Admin.brand
{
    public interface IBrandUpdate
    {
        CommonResponse<BrandUpdateResponse> UpdateBrand(BrandUpdateRequest objRequest);
    }
}
