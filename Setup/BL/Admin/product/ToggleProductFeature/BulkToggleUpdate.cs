using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.product.ToggleProductFeature;
using Setup.Request.Admin.common;
using Setup.Request.Admin.product.ToggleProductFeature;
using Setup.Response.Admin.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.product.ToggleProductFeature
{
    public class BulkToggleUpdate : IBulkToggleUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public BulkToggleUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<UpdateBulkToggleResponse> BulkToggle(UpdateBulkToggleRequest objRequest)
        {
            CommonResponse<UpdateBulkToggleResponse> response = new CommonResponse<UpdateBulkToggleResponse>();

            try
            {

                // Convert array parameters to comma-separated strings
                string IDs = string.Join(",", objRequest.ID);
                string columnNames = string.Join(",", objRequest.ColumnName);

                #region Parameters
                MySqlParameter[] parameters =
                {
                   new MySqlParameter("@SPId", MySqlDbType.Int32) {Value = IDs },
                   new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = objRequest.Status },
                   new MySqlParameter("@SPColumnName", MySqlDbType.String) {Value = columnNames }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateBulkToggle", ds, TableName, parameters);

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