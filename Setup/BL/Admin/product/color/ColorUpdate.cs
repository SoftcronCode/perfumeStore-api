using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.product.color;
using Setup.Request.Admin.product.color;
using Setup.Response.Admin.product.color;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.product.color
{
    public class ColorUpdate : IColorUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public ColorUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<ColorUpdateResponse> UpdateColor(ColorUpdateRequest request)
        {
            CommonResponse<ColorUpdateResponse> response = new CommonResponse<ColorUpdateResponse>();

            try
            {
                #region Parameters

                MySqlParameter[] parameters = {
                new MySqlParameter("@SPColorId", MySqlDbType.Int32) {Value = request.ColorId },
                new MySqlParameter("@SPColor", MySqlDbType.String) {Value = request.ColorName },
                new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = request.Status }
                };

                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateColor", ds, TableName, parameters);
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
