using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.category;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;
using SixLabors.ImageSharp;
using System.Data;
using System.Drawing;

namespace Setup.BL.Admin.category
{
    public class AddCategory : IAddCategory
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public AddCategory(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddCategoryResponse> InsertCategory(AddCategoryRequest objRequest)
        {
            CommonResponse<AddCategoryResponse> response = new CommonResponse<AddCategoryResponse>();

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
                        string targetDirectory = Path.Combine(_environment.WebRootPath + "\\Category");
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
                            new MySqlParameter("@SPName", MySqlDbType.String) {Value = objRequest.Name },
                            new MySqlParameter("@SPSlug", MySqlDbType.String) {Value = objRequest.Slug },
                            new MySqlParameter("@SPImage", MySqlDbType.String) {Value = uniqueFilename },
                            new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = objRequest.Status }
                        };
                        #endregion

                        DataSet ds = new DataSet();
                        string[] TableName = { "Response" };
                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertCategory", ds, TableName, parameters);
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
