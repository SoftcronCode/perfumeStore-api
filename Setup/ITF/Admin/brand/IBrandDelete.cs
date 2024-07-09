using Setup.DAL;
using Setup.Request.Admin.brand;


namespace Setup.ITF.Admin.brand
{
    public interface IBrandDelete
    {
        CommonResponse<BrandDeleteResponse> DeleteBrand(BrandDeleteRequest objRequest);
    }
}
