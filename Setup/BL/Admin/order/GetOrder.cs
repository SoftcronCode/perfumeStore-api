using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.Admin.order;
using Setup.Request.Admin.order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.order
{
    public class GetOrder : IGetOrder
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public GetOrder(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<GetOrderResponse> FetchOrder(GetOrderRequest request)
        {
            CommonResponse<GetOrderResponse> response = new CommonResponse<GetOrderResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {

                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "FetchOrderForAdmin", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (ds.Tables.Count > 1 && ds.Tables[1].Columns.Contains("ResponseCode"))
                    {
                        response.ResponseCode = Convert.ToInt32(ds.Tables[1].Rows[0]["ResponseCode"]);
                        response.ResponseMessage = Convert.ToString(ds.Tables[1].Rows[0]["ResponseMessage"]);
                        response.ResponseData = null;
                    }

                    else if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;
                        response.Token = null;
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.ResponseMessage = "No Record To Display!";
                        response.ResponseData = null;
                    }
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


        public CommonResponse<GetOrderDetailResponse> FetchOrderDetailByID(GetOrderDetailRequest request)
        {
            CommonResponse<GetOrderDetailResponse> response = new CommonResponse<GetOrderDetailResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPOrderId", MySqlDbType.Int32) {Value = request.OrderId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "FetchOrderDetailById", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (ds.Tables.Count > 1 && ds.Tables[1].Columns.Contains("ResponseCode"))
                    {
                        response.ResponseCode = Convert.ToInt32(ds.Tables[1].Rows[0]["ResponseCode"]);
                        response.ResponseMessage = Convert.ToString(ds.Tables[1].Rows[0]["ResponseMessage"]);
                        response.ResponseData = null;
                    }

                    else if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;
                        response.Token = null;
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.ResponseMessage = "No Record To Display!";
                        response.ResponseData = null;
                    }
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
