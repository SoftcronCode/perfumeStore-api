using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.coupon;
using Setup.Request.Admin.category;
using Setup.Request.Admin.coupon;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.coupon
{
    public class CouponDelete : ICouponDelete
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public CouponDelete(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<CouponDeleteResponse> DeleteCoupon(CouponDeleteRequest objRequest)
        {
            CommonResponse<CouponDeleteResponse> response = new CommonResponse<CouponDeleteResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                   new MySqlParameter("@SPCoupon_id", MySqlDbType.Int32) {Value = objRequest.ID }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "DeleteCoupon", ds, TableName, parameters);

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
