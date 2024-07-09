using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using Setup.Response.User.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Setup.BL.User.auth
{
    public class Login : ILogin
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;
        private readonly CommonMethod commonMethod;

        public Login(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
            commonMethod = new CommonMethod(_configuration);
        }


        public CommonResponse<LoginResponse> AppLogin(LoginRequest objRequest)
        {
            CommonResponse<LoginResponse> response = new CommonResponse<LoginResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPEmail", MySqlDbType.String) {Value = objRequest.Email },
                    new MySqlParameter("@SPPassword", MySqlDbType.String) {Value = objRequest.PassWord },
                    new MySqlParameter("@SPSessionId", MySqlDbType.String) {Value = objRequest.SessionId}
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "UserData" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UserLogin", ds, TableName, parameters);
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
