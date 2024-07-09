using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.Request.Admin.product;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text
    ;
using System.Threading.Tasks;

namespace Setup.BL.Admin.product
{
    public class ProductUpdate : IProductUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public ProductUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        CommonResponse<ProductUpdateResponse> response = new CommonResponse<ProductUpdateResponse>();

        public CommonResponse<ProductUpdateResponse> UpdateProduct(ProductUpdateRequest objRequest)
        {

            try
            {
                if (objRequest.Image != null && objRequest.Image.Count > 0)
                {
                    string commamSepratedNames = "";
                    bool allFilesAllowed = true;

                    foreach (IFormFile file in objRequest.Image)
                    {
                        string fileExtension = Path.GetExtension(file.FileName).ToLower();
                        string[] allowdedExtensions = { ".png", ".jpeg", ".jpg", ".webp" };
                        if (!allowdedExtensions.Contains(fileExtension))
                        {
                            allFilesAllowed = false; // Marking flag as false if any file is not allowed
                            break;
                        }
                    }

                    if (!allFilesAllowed)
                    {
                        response.ResponseCode = 0;
                        response.ResponseMessage = "Only PNG, JPG, JPEG, and WebP images are allowed";
                        response.ResponseData = null;
                        return response;
                    }
                    else
                    {
                        foreach (IFormFile file in objRequest.Image)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            string webRootPath = _environment.WebRootPath;
                            string targetDirectory = Path.Combine(_environment.WebRootPath + "\\Product");
                            string uniqueFilename = Guid.NewGuid().ToString() + "_" + fileName;
                            string filePath = Path.Combine(targetDirectory, uniqueFilename);
                            commamSepratedNames += uniqueFilename + ",";
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                stream.Flush();
                            }
                        }

                        string ImageNames = commamSepratedNames.TrimEnd(',');
                        SaveData(objRequest, ImageNames);
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


        protected void SaveData(ProductUpdateRequest objRequest, string? Filename)
        {
            #region Parameters

            MySqlParameter[] parameters = {
                new MySqlParameter("@SPId", MySqlDbType.Int32) {Value = objRequest.ID },
                new MySqlParameter("@SPcat_id", MySqlDbType.Int32) {Value = objRequest.Cat_Id },
                new MySqlParameter("@SPsub_cat_id", MySqlDbType.Int32) {Value = objRequest.Sub_Cat_Id },
                new MySqlParameter("@SPName", MySqlDbType.String) {Value = objRequest.Name },
                new MySqlParameter("@SPSlug", MySqlDbType.String) {Value = objRequest.Slug },
                new MySqlParameter("@SPshort_description", MySqlDbType.String) {Value = objRequest.Short_Description },
                new MySqlParameter("@SPdescription", MySqlDbType.String) {Value = objRequest.Description },
                new MySqlParameter("@SPprice", MySqlDbType.Int32) {Value = objRequest.Price },
                new MySqlParameter("@SPmrp", MySqlDbType.Int32) {Value = objRequest.Mrp },
                new MySqlParameter("@SPqty", MySqlDbType.Int32) {Value = objRequest.Qty },
                new MySqlParameter("@SPsizeId", MySqlDbType.Int32) {Value = objRequest.SizeId },
                new MySqlParameter("@SPcolorId", MySqlDbType.Int32) {Value = objRequest.ColorId },
                new MySqlParameter("@SPsku_code", MySqlDbType.String) {Value = objRequest.Sku_Code },
                new MySqlParameter("@SPhsn_code", MySqlDbType.String) {Value = objRequest.Hsn_Code },
                new MySqlParameter("@SPproduct_weight", MySqlDbType.Int32) {Value = objRequest.Product_Weight },
                new MySqlParameter("@SPshipping_weight", MySqlDbType.Int32) {Value = objRequest.Shipping_Weight },
                new MySqlParameter("@SPdispatch_time", MySqlDbType.Int32) {Value = objRequest.Dispatch_Time },
                new MySqlParameter("@SPdelivery_time", MySqlDbType.Int32) {Value = objRequest.Delivery_Time },
                new MySqlParameter("@SPbrand_id", MySqlDbType.Int32) {Value = objRequest.Brand_Id },
                new MySqlParameter("@SPgst", MySqlDbType.Int32) {Value = objRequest.Gst },
                new MySqlParameter("@SPpacked_by", MySqlDbType.String) {Value = objRequest.Packed_By },
                new MySqlParameter("@SPmanufactured_by", MySqlDbType.String) {Value = objRequest.Manufactured_By },
                new MySqlParameter("@SPproduct_material", MySqlDbType.String) {Value = objRequest.Product_Material },
                new MySqlParameter("@SPcod", MySqlDbType.Int32) {Value = objRequest.Cod },
                new MySqlParameter("@SPbest_seller", MySqlDbType.Int32) {Value = objRequest.Best_seller },
                new MySqlParameter("@SPfeatured_products", MySqlDbType.Int32) {Value = objRequest.Featured_Products },
                new MySqlParameter("@SPdiscounted_products", MySqlDbType.Int32) {Value = objRequest.Discounted_Products },
                new MySqlParameter("@SPnew_arrival", MySqlDbType.Int32) {Value = objRequest.New_Arrival },
                new MySqlParameter("@SPis_delete", MySqlDbType.Int32) {Value = objRequest.Is_Delete },
                new MySqlParameter("@SPis_active", MySqlDbType.Int32) {Value = objRequest.Status },
                new MySqlParameter("@SPvideo_link", MySqlDbType.String) {Value = objRequest.Video_Link },
                new MySqlParameter("@SPImage", MySqlDbType.String) { Value = Filename != null ? Filename : DBNull.Value },
            };

            #endregion

            DataSet ds = new DataSet();
            string[] TableName = { "Response" };
            dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateProduct", ds, TableName, parameters);
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
