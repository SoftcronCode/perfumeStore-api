using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.order;
using Setup.Request.Admin.order;
using Setup.Request.Admin.product.size;
using Setup.Response.Admin.product.size;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.order
{
    public class OrderUpdate : IOrderUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public OrderUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<OrderUpdateResponse> UpdateOrder(OrderUpdateRequest request)
        {
            CommonResponse<OrderUpdateResponse> response = new();

            try
            {
                #region Parameters

                MySqlParameter[] parameters = {
                    new MySqlParameter("@SPOrderId", MySqlDbType.Int32) {Value = request.orderID },
                    new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = request.orderStatusID },
                    new MySqlParameter("@SPTrackingID", MySqlDbType.String) {Value = request.trackingID },
                    new MySqlParameter("@SPCourierName", MySqlDbType.String) {Value = request.courierName },
                    new MySqlParameter("@SPReason", MySqlDbType.String) {Value = request.reason },
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateOrderForAdmin", ds, TableName, parameters);
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
