using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.contact;
using Setup.Request.Admin.category;
using Setup.Request.Admin.contact;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using Org.BouncyCastle.Asn1.Ocsp;
namespace Setup.BL.Admin.contact
{
    public class AddContact: IAddContact
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public AddContact(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<AddContactResponse> InsertContact(AddContactRequest objRequest)
        {
            CommonResponse<AddContactResponse> response = new CommonResponse<AddContactResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                 
                    new MySqlParameter("@SPphone", MySqlDbType.String) {Value = objRequest.Phone},
                    new MySqlParameter("@SPemail", MySqlDbType.String) {Value = objRequest.Email },
                    new MySqlParameter("@SPaddress", MySqlDbType.String) {Value = objRequest.Address },
                    new MySqlParameter("@SPgoogle_map", MySqlDbType.String) {Value = objRequest.google_map },
                    new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = objRequest.Status },
                 };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "InsertContact", ds, TableName, parameters);
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
