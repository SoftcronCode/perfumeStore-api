using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.Admin.category;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.category
{
    public class CategoryUpdate : ICategoryUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public CategoryUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        CommonResponse<CategoryUpdateResponse> response = new CommonResponse<CategoryUpdateResponse>();

        public CommonResponse<CategoryUpdateResponse> UpdateCategory([FromForm] CategoryUpdateRequest objRequest)
        {
            try
            {
                if (objRequest.Image != null && objRequest.Image.Length > 0)
                {
                    string fileName = Path.GetFileName(objRequest.Image.FileName);
                    string contentType = objRequest.Image.ContentType;
                    string fileExtension = Path.GetExtension(fileName);

                    string[] allowdedExtensions = { ".png", ".jpeg", ".jpg", ".webp" };
                    if (allowdedExtensions.Contains(fileExtension.ToLower()))
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

                        string webRootPath = _environment.WebRootPath;
                        string targetDirectory = Path.Combine(_environment.WebRootPath + "\\Category");
                        string uniqueFilename = Guid.NewGuid().ToString() + "_" + fileName;
                        string filePath = Path.Combine(targetDirectory, uniqueFilename);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            objRequest.Image.CopyTo(stream);
                            stream.Flush();
                        }

                        SaveData(objRequest, uniqueFilename);

                    }
                    else
                    {
                        response.ResponseCode = 0;
                        response.ResponseMessage = "Only PNG, JPG, JPEG, and WebP images are allowed";
                        response.ResponseData = null;
                    }
                }
                else
                {
                    SaveData(objRequest, null);
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 0;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }


        protected void SaveData(CategoryUpdateRequest objRequest, string? Filename)
        {
            #region Parameters

            MySqlParameter[] parameters = {
                new MySqlParameter("@SPCat_id", MySqlDbType.Int32) {Value = objRequest.ID },
                new MySqlParameter("@SPName", MySqlDbType.String) {Value = objRequest.Name },
                new MySqlParameter("@SPSlug", MySqlDbType.String) {Value = objRequest.Slug },
                new MySqlParameter("@SPImage", MySqlDbType.String) { Value = Filename != null ? Filename : DBNull.Value }
            };

            #endregion

            DataSet ds = new DataSet();
            string[] TableName = { "Response" };
            dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateCategory", ds, TableName, parameters);
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
    }
}
