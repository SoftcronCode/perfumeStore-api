using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.company_detail;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.brand;
using Setup.Request.Admin.company_detail;
using Setup.Request.Admin.product;
using SixLabors.ImageSharp;
using System.Data;
using System.Drawing;


namespace Setup.BL.Admin.company_detail
{
    public class AddCompanyDetail : IAddCompanyDetail
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public AddCompanyDetail(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddCompanyDetailResponse> InsertCompanyDetail(AddCompanyDetailRequest objRequest)
        {
            CommonResponse<AddCompanyDetailResponse> response = new CommonResponse<AddCompanyDetailResponse>();

            try
            {
                if (objRequest.Company_logo != null && objRequest.Company_logo.Length > 0)
                {
                    using (var image = Image.Load(objRequest.Company_logo.OpenReadStream()))
                    {
                        if (image.Width != 130 || image.Height != 130)
                        {
                            response.ResponseCode = 0;
                            response.ResponseMessage = "Image dimensions must be 130x130 pixels";
                            return response;
                        }
                    }

                    string fileName = Path.GetFileName(objRequest.Company_logo.FileName);
                    string contentType = objRequest.Company_logo.ContentType;
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
                            objRequest.Company_logo.CopyTo(stream);
                            stream.Flush();
                        }

                        #region Parameters
                        MySqlParameter[] parameters =
                        {
                             new MySqlParameter("@SPname", MySqlDbType.String) {Value = objRequest.name},
                             new MySqlParameter("@SPemail", MySqlDbType.String) {Value = objRequest.email },
                            new MySqlParameter("@SPaddress", MySqlDbType.String) {Value = objRequest.address },
                            new MySqlParameter("@SPphone", MySqlDbType.String) {Value = objRequest.phone },
                            new MySqlParameter("@SPCompany_logo", MySqlDbType.String) {Value = uniqueFilename },
                            new MySqlParameter("@SPgoogle_link", MySqlDbType.String) {Value = objRequest.google_link },
                            new MySqlParameter("@SPinstagram_link", MySqlDbType.String) {Value = objRequest.instagram_link },
                            new MySqlParameter("@SPfacebook_link", MySqlDbType.String) {Value = objRequest.facebook_link },
                            new MySqlParameter("@SPtwitter_link", MySqlDbType.String) {Value = objRequest.twitter_link },
                           new MySqlParameter("@SPyoutube_link", MySqlDbType.String) {Value = objRequest.youtube_link },
                            new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = objRequest.status }
                        };
                        #endregion

                        DataSet ds = new DataSet();
                        string[] TableName = { "Response" };
                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertCompanyDetail", ds, TableName, parameters);
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
