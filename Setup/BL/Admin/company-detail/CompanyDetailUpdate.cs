using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.Admin.company_detail;
using Setup.Request.Admin.company_detail;
using System.Data;
using SixLabors.ImageSharp;


namespace Setup.BL.Admin.company_detail
{
    public class CompanyDetailUpdate : ICompanyDetailUpdate
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public CompanyDetailUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }
        public CommonResponse<CompanyDetailUpdateResponse> UpdateCompanyDetail(CompanyDetailUpdateRequest request)
        {
            CommonResponse<CompanyDetailUpdateResponse> response = new CommonResponse<CompanyDetailUpdateResponse>();
            try
            {
                if (request.Company_logo != null && request.Company_logo.Length > 0)
                {
                    using (var image = Image.Load(request.Company_logo.OpenReadStream()))
                    {
                        if (image.Width != 130 || image.Height != 130)
                        {
                            response.ResponseCode = 0;
                            response.ResponseMessage = "Image dimensions must be 130x130 pixels";
                            return response;
                        }
                    }

                    string fileName = Path.GetFileName(request.Company_logo.FileName);
                    string contentType = request.Company_logo.ContentType;
                    string fileExtension = Path.GetExtension(fileName);

                    string[] allowdedExtensions = { ".png", ".jpeg", ".jpg", ".webp" };
                    if (allowdedExtensions.Contains(fileExtension.ToLower()))
                    {
                        string webRootPath = _environment.WebRootPath;
                        string targetDirectory = Path.Combine(_environment.WebRootPath + "\\company-detail");
                        string uniqueFilename = Guid.NewGuid().ToString() + "_" + fileName;
                        string filePath = Path.Combine(targetDirectory, uniqueFilename);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            request.Company_logo.CopyTo(stream);
                            stream.Flush();
                        }

                        #region Parameters
                        MySqlParameter[] parameters =
                        {
                             new MySqlParameter("@SPid", MySqlDbType.Int32) {Value = request.ID},
                             new MySqlParameter("@SPname", MySqlDbType.String) {Value = request.name},
                             new MySqlParameter("@SPemail", MySqlDbType.String) {Value = request.email },
                            new MySqlParameter("@SPaddress", MySqlDbType.String) {Value = request.address },
                            new MySqlParameter("@SPphone", MySqlDbType.String) {Value = request.phone },
                            new MySqlParameter("@SPCompany_logo", MySqlDbType.String) {Value = uniqueFilename },
                            new MySqlParameter("@SPgoogle_link", MySqlDbType.String) {Value = request.google_link },
                            new MySqlParameter("@SPinstagram_link", MySqlDbType.String) {Value = request.instagram_link },
                            new MySqlParameter("@SPfacebook_link", MySqlDbType.String) {Value = request.facebook_link },
                            new MySqlParameter("@SPtwitter_link", MySqlDbType.String) {Value = request.twitter_link },
                           new MySqlParameter("@SPyoutube_link", MySqlDbType.String) {Value = request.youtube_link },
                            new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = request.status }
                        };
                        #endregion

                        DataSet ds = new DataSet();
                        string[] TableName = { "Response" };
                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateCompanyDetails", ds, TableName, parameters);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                            response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                        }
                        else
                        {
                            response.ResponseCode = 0;
                            response.ResponseMessage = "No Data Found !";
                            response.ResponseData = null;
                        }
                    }
                    else
                    {
                        response.ResponseCode = 0;
                        response.ResponseMessage = "Only PNG, JPG, JPEG, and WebP images are allowed";
                        response.ResponseData = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 0;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }
    }
}
