using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.product.product_image;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.product_image;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.product.product_image
{
    public class ProductImageDelete : IProductImageDelete
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public ProductImageDelete(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<ProductImageDeleteResponse> DeleteProductImage(ProductImageDeleteRequest objRequest)
        {
            CommonResponse<ProductImageDeleteResponse> response = new CommonResponse<ProductImageDeleteResponse>();

            try
            {
                #region Retrieve Image Data
                // Fetch data of the image using a stored procedure or any other method            

                MySqlParameter[] imageParameters =
                {
                    new MySqlParameter("@SPid", MySqlDbType.Int32) {Value = objRequest.ID }
                };

                DataSet imageData = new DataSet();
                string[] imageTableName = { "Response", "Record" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "FetchProductImage", imageData, imageTableName, imageParameters);

                // Check if data is retrieved successfully
                if (imageData != null && imageData.Tables.Count > 0 && imageData.Tables[0].Rows.Count > 0)
                {
                    string? imagePath = Convert.ToString(imageData.Tables[1].Rows[0]["image_name"]);

                    #region Delete Server Image
                    string serverImagePath = Path.Combine(_environment.WebRootPath + "\\Product", imagePath);

                    if (File.Exists(serverImagePath))
                    {
                        File.Delete(serverImagePath);

                        #region Delete Image from Database
                        // Proceed with deleting the image from the database
                        DataSet deleteResult = new DataSet();
                        string[] deleteTableName = { "Result" };
                        MySqlParameter[] deleteParameters =
                        {
                             new MySqlParameter("@SPid", MySqlDbType.Int32) {Value = objRequest.ID }
                        };

                        dataAccess.ExecuteQuery(CommandType.StoredProcedure, "DeleteProductImage", deleteResult, deleteTableName, deleteParameters);

                        // Check delete operation result
                        if (deleteResult != null && deleteResult.Tables.Count > 0 && deleteResult.Tables[0].Rows.Count > 0)
                        {
                            response.ResponseCode = Convert.ToInt32(deleteResult.Tables[0].Rows[0]["ResponseCode"]);
                            response.ResponseMessage = Convert.ToString(deleteResult.Tables[0].Rows[0]["ResponseMessage"]);
                        }
                        else
                        {
                            response.ResponseCode = 0;
                            response.ResponseMessage = Convert.ToString(deleteResult.Tables[0].Rows[0]["ResponseMessage"]);
                            return response;
                        }
                        #endregion
                    }
                    else
                    {
                        response.ResponseCode = 0;
                        response.ResponseMessage = "Server Image not found!";
                        return response;
                    }
                    #endregion
                }
                else
                {
                    response.ResponseCode = 0;
                    response.ResponseMessage = "No Image Data Found !";
                    return response;
                }
                #endregion
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
