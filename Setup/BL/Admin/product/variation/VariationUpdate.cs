using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.Admin.product;
using Setup.ITF.Admin.product.variation;
using Setup.Request.Admin.product;
using Setup.Request.Admin.product.variation;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.product.variation
{
    public class VariationUpdate : IVariationUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public VariationUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        CommonResponse<VariationUpdateResponse> response = new CommonResponse<VariationUpdateResponse>();

        public CommonResponse<VariationUpdateResponse> UpdateVariation([FromForm] VariationUpdateRequest objRequest)
        {
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPVariationId", MySqlDbType.Int32) {Value = objRequest.variation_id },
                    new MySqlParameter("@SPsize_id", MySqlDbType.Int32) {Value = objRequest.size_id },
                    new MySqlParameter("@SPcolor_id", MySqlDbType.Int32) {Value = objRequest.color_id },
                    new MySqlParameter("@SPmrp", MySqlDbType.Int32) {Value = objRequest.mrp },
                    new MySqlParameter("@SPprice", MySqlDbType.Int32) {Value = objRequest.price },
                    new MySqlParameter("@SPqty", MySqlDbType.Int32) {Value = objRequest.qty },
                    new MySqlParameter("@SPImage", MySqlDbType.Int32) {Value = objRequest.ImageId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateVariation", ds, TableName, parameters);
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
