using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.contact;
using Setup.Request.Admin.about;
using Setup.Request.Admin.category;
using Setup.Request.Admin.contact;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.contact
{
    public class ContactUpdate : IContactUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public ContactUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }
        public CommonResponse<ContactUpdateResponse> UpdateContact(ContactUpdateRequest request)
        {
            CommonResponse<ContactUpdateResponse> response = new CommonResponse<ContactUpdateResponse>();
            try
            {
                #region Parameters

                MySqlParameter[] parameters = {
                new MySqlParameter("@SPid", MySqlDbType.Int32) {Value = request.ID},
                new MySqlParameter("@SPphone", MySqlDbType.String) {Value = request.Phone },
                 new MySqlParameter("@SPemail", MySqlDbType.String) {Value = request.Email},
                 new MySqlParameter("@SPaddress", MySqlDbType.String) {Value = request.Address},
                new MySqlParameter("@SPgoogle_map", MySqlDbType.Int32) {Value = request.Status },
                new MySqlParameter("@SPStatus", MySqlDbType.String) {Value = request.google_map}
                };

                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateContact", ds, TableName, parameters);
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
