using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.Admin.auth;
using Setup.Request.User.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.auth
{
    public class UpdateUserPassword : IUpdateUserPassword
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;
        private readonly CommonMethod commonMethod;

        public UpdateUserPassword(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
            commonMethod = new CommonMethod(_configuration);
        }
        public CommonResponse<UpdateUserPasswordResponse> UpdateUserPasswords(UpdateUserPasswordRequest objRequest)
        {
            CommonResponse<UpdateUserPasswordResponse> response = new CommonResponse<UpdateUserPasswordResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPid", MySqlDbType.String) {Value = objRequest.ID },
                    new MySqlParameter("@SPemail", MySqlDbType.String) {Value = objRequest.Email },
                    new MySqlParameter("@SPStatus", MySqlDbType.String) {Value = objRequest.Status },
                    new MySqlParameter("@SPpassword", MySqlDbType.String) {Value = objRequest.Password },
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "AdminData" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateUserPassword", ds, TableName, parameters);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;

                        var jwtToken = commonMethod.GenerateToken(objRequest.Email);
                        response.Token = jwtToken;
                    }
                    else
                    {
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
