using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using Setup.ITF.Admin.product.variation;
using Setup.Request.Admin.product.variation;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Setup.BL.Admin.product.variation
{
    public class AddVariation : IAddVariation
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public AddVariation(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddVariationResponse> InsertVariation(AddVariationRequest objRequest)
        {
            CommonResponse<AddVariationResponse> response = new CommonResponse<AddVariationResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPproduct_id", MySqlDbType.Int32) {Value = objRequest.product_id },
                    new MySqlParameter("@SPsize_id", MySqlDbType.Int32) {Value = objRequest.size_id },
                    new MySqlParameter("@SPcolor_id", MySqlDbType.Int32) {Value = objRequest.color_id },
                    new MySqlParameter("@SPmrp", MySqlDbType.Int32) {Value = objRequest.mrp },
                    new MySqlParameter("@SPprice", MySqlDbType.Int32) {Value = objRequest.price },
                    new MySqlParameter("@SPqty", MySqlDbType.Int32) {Value = objRequest.qty },
                    new MySqlParameter("@SPImage", MySqlDbType.Int32) {Value = objRequest.ImageID }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertVariation", ds, TableName, parameters);
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
            catch (Exception ex)
            {
                response.ResponseCode = 0;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }
    }
}
