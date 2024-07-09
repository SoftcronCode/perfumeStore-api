using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.coupon;
using Setup.Request.Admin.coupon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.coupon
{
    public class CouponUpdate : ICouponUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public CouponUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<UpdateCouponResponse> UpdateCoupon(CouponUpdateRequest request)
        {
            CommonResponse<UpdateCouponResponse> response = new();

            try
            {
                #region Parameters

                MySqlParameter[] parameters = {
                    new MySqlParameter("@SPcoupon_name", MySqlDbType.String) {Value = request.coupon_name },
                    new MySqlParameter("@SPcoupon_value", MySqlDbType.String) {Value = request.coupon_value },
                    new MySqlParameter("@SPcoupon_type", MySqlDbType.String) {Value = request.coupon_type },
                    new MySqlParameter("@SPcart_min_value", MySqlDbType.String) {Value = request.cart_min_value },
                    new MySqlParameter("@SPexpiry_date", MySqlDbType.Date) {Value = DateTime.Parse(request.expiry_date).ToString("yyyy-mm-dd") },
                    new MySqlParameter("@SPtotal_uses", MySqlDbType.Int32) {Value = request.total_uses },
                    new MySqlParameter("@SPremaining_uses", MySqlDbType.Int32) {Value = request.remaining_uses },
                    new MySqlParameter("@SPmin_purchase_amount", MySqlDbType.Int32) {Value = request.min_purchase_amount },
                    new MySqlParameter("@SPusage_limit", MySqlDbType.String) {Value = request.usage_limit },
                    new MySqlParameter("@SPdiscount", MySqlDbType.Int32) {Value = request.discount },
                    new MySqlParameter("@SPstatus", MySqlDbType.Int32) {Value = request.Status }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateCoupon", ds, TableName, parameters);
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
