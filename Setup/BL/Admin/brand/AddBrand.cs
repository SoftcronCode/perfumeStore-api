using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.brand;
using Setup.Request.Admin.brand;
using System.Data;
using SixLabors.ImageSharp;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;

namespace Setup.BL.Admin.brand
{
    public class AddBrand : IAddBrand
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public AddBrand(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddBrandResponse> InsertBrand(AddBrandRequest objRequest)
        {
            CommonResponse<AddBrandResponse> response = new CommonResponse<AddBrandResponse>();

            try
            {
                if (objRequest.Image != null && objRequest.Image.Length > 0)
                {
                    using (var image = Image.Load(objRequest.Image.OpenReadStream()))
                    {
                        if (image.Width != 100 || image.Height != 100)
                        {
                            response.ResponseCode = 0;
                            response.ResponseMessage = "Image dimensions must be 100x100 pixels";
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
                        string targetDirectory = Path.Combine(_environment.WebRootPath + "\\brand");
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
                            new MySqlParameter("@SPbrand_name", MySqlDbType.String) {Value = objRequest.Name },
                            new MySqlParameter("@SPbrand_logo", MySqlDbType.String) {Value = uniqueFilename },
                            new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = objRequest.Status }
                        };
                        #endregion

                        DataSet ds = new DataSet();
                        string[] TableName = { "Response" };
                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertBrand", ds, TableName, parameters);
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
