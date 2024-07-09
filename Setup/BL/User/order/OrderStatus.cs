using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.order;
using Setup.Request.User.order;
using Setup.Response.User.order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.order
{
    public class OrderStatus : IOrderStatus
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public OrderStatus(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        #region Create User Order Method  
        public CommonResponse<OrderStatusResponse> UpdateOrderStatus(OrderStatusRequest objRequest)
        {
            CommonResponse<OrderStatusResponse> response = new CommonResponse<OrderStatusResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPOrderId", MySqlDbType.Int32) {Value = objRequest.OrderId },
                    new MySqlParameter("@SPStatusId", MySqlDbType.Int32) {Value = objRequest.StatusId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "UpdateOrderStatus", ds, TableName, parameters);
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

        #endregion
    }
}
