using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;
using SixLabors.ImageSharp;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Setup.ITF.Admin.blog;
using Setup.Request.Admin.blog;
using Microsoft.AspNetCore.Http;
using Setup.Request.Admin.product;

namespace Setup.BL.Admin.blog
{
    public class BlogUpdate : IBlogUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public BlogUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<BlogUpdateResponse> UpdateBlog(BlogUpdateRequest objRequest)
        {
            CommonResponse<BlogUpdateResponse> response = new CommonResponse<BlogUpdateResponse>();

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
                        string targetDirectory = Path.Combine(_environment.WebRootPath + "\\blog");
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
                            new MySqlParameter("@SPcategory_id", MySqlDbType.Int32) {Value = objRequest.CategoryId },
                            new MySqlParameter("@SPcategory_name", MySqlDbType.String) {Value = objRequest.CategoryName },
                            new MySqlParameter("@SPsub_cat_id", MySqlDbType.Int32) {Value = objRequest.SubCategoryId },
                            new MySqlParameter("@SPsub_cat_name", MySqlDbType.String) {Value = objRequest.SubCategoryName },
                            new MySqlParameter("@SPblog_tag_id", MySqlDbType.String) {Value = objRequest.BlogTagId },
                            new MySqlParameter("@SPblog_title", MySqlDbType.String) {Value = objRequest.BlogTitle },
                            new MySqlParameter("@SPblog_description", MySqlDbType.String) {Value = objRequest.BlogDescription },
                            new MySqlParameter("@SPblog_friendly_url", MySqlDbType.String) {Value = objRequest.BlogFriendlyUrl },
                            new MySqlParameter("@SPtag_name", MySqlDbType.String) {Value = objRequest.TagName },
                            new MySqlParameter("@SPpage_title", MySqlDbType.String) {Value = objRequest.PageTitle },
                            new MySqlParameter("@SPmeta_Key", MySqlDbType.String) {Value = objRequest.MetaKey },
                            new MySqlParameter("@SPmeta_description", MySqlDbType.String) {Value = objRequest.MetaDescription },
                            new MySqlParameter("@SPvideo_link", MySqlDbType.String) {Value = objRequest.VideoLink },
                            new MySqlParameter("@SPblog_image", MySqlDbType.String) {Value = uniqueFilename },
                            new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = objRequest.Status }
                        };
                        #endregion

                        DataSet ds = new DataSet();
                        string[] TableName = { "Response" };
                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateBlog", ds, TableName, parameters);
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
