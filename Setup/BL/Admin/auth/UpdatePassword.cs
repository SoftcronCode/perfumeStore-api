using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.Admin.auth;
using Setup.Request.Admin.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.auth
{
    public class UpdatePassword : IUpdatePassword
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;
        private readonly CommonMethod commonMethod;

        public UpdatePassword(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
            commonMethod = new CommonMethod(_configuration);
        }
        public CommonResponse<UpdatePasswordResponse> UpdateAdminPassword(UpdatePasswordRequest objRequest)
        {
            CommonResponse<UpdatePasswordResponse> response = new CommonResponse<UpdatePasswordResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPemail", MySqlDbType.String) {Value = objRequest.EmailId },
                    new MySqlParameter("@SPpassword", MySqlDbType.String) {Value = objRequest.Password }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateAdminPassword", ds, TableName, parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);                    
                }
                else
                {
                    response.ResponseCode = 0;
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
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
