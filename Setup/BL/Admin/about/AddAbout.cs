using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.Admin.about;
using Setup.Request.Admin.about;
using System.Data;
using SixLabors.ImageSharp;


namespace Setup.BL.Admin.about
{
    public class AddAbout : IAddAbout
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public AddAbout(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddAboutResponse> InsertAbout(AddAboutRequest objRequest)
        {
            CommonResponse<AddAboutResponse> response = new CommonResponse<AddAboutResponse>();

            try
            {
                if (objRequest.Image != null && objRequest.Image.Length > 0)
                {
                    using (var image = Image.Load(objRequest.Image.OpenReadStream()))
                    {
                        if (image.Width != 130 || image.Height != 130)
                        {
                            response.ResponseCode = 0;
                            response.ResponseMessage = "Image dimensions must be 130x130 pixels";
                            return response;
                        }
                    }

                    string fileName = Path.GetFileName(objRequest.Image.FileName);
                    string contentType = objRequest.Image.ContentType;
                    string fileExtension = Path.GetExtension(fileName);

                    string[] allowdedExtensions = { ".png", ".jpeg", ".jpg", ".webp" };
                    if (allowdedExtensions.Contains(fileExtension.ToLower()))
                    {
                        string webRootPath = _environment.WebRootPath;
                        string targetDirectory = Path.Combine(_environment.WebRootPath + "\\about");
                        string uniqueFilename = Guid.NewGuid().ToString() + "_" + fileName;
                        string filePath = Path.Combine(targetDirectory, uniqueFilename);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            objRequest.Image.CopyTo(stream);
                            stream.Flush();
                        }

                        #region Parameters
                        MySqlParameter[] parameters =
                        {
                             new MySqlParameter("@SPabout_title1", MySqlDbType.String) {Value = objRequest.AboutTitle1},
                            new MySqlParameter("@SPabout_description1", MySqlDbType.String) {Value = objRequest.AboutDescription1 },
                            new MySqlParameter("@SPabout_title2", MySqlDbType.String) {Value = objRequest.AboutTitle2},
                            new MySqlParameter("@SPabout_description2", MySqlDbType.String) {Value = objRequest.AboutDescription2 },
                            new MySqlParameter("@SPabout_title3", MySqlDbType.String) {Value = objRequest.AboutTitle3},
                            new MySqlParameter("@SPabout_description3", MySqlDbType.String) {Value = objRequest.AboutDescription3 },
                            new MySqlParameter("@SPmeta_key", MySqlDbType.String) {Value = objRequest.MetaKey },
                            new MySqlParameter("@SPmeta_description", MySqlDbType.String) {Value = objRequest.MetaDescription },
                            new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value =  objRequest.Status },
                            new MySqlParameter("@SPabout_image", MySqlDbType.String) {Value = uniqueFilename }
                        };
                        #endregion

                        DataSet ds = new DataSet();
                        string[] TableName = { "Response" };
                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertAbout", ds, TableName, parameters);
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
