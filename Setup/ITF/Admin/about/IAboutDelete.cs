using Setup.DAL;
using Setup.Request.Admin.about;


namespace Setup.ITF.Admin.about
{
    public interface IAboutDelete
    {
        CommonResponse<AboutDeleteResponse> DeleteAbout(AboutDeleteRequest objRequest);
    }
}
