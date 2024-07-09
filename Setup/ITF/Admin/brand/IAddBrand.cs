using Setup.DAL;
using Setup.Request.Admin.brand;


namespace Setup.ITF.Admin.brand
{
    public interface IAddBrand
    {
        CommonResponse<AddBrandResponse> InsertBrand(AddBrandRequest objRequest);
    }
}