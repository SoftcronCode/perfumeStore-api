using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.contact;
using Setup.Request.Admin.contact;
using System.Data;


namespace Setup.BL.Admin.contact
{
    public class ContactDelete : IContactDelete
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public ContactDelete(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<ContactDeleteResponse> DeleteContact(ContactDeleteRequest objRequest)
        {
            CommonResponse<ContactDeleteResponse> response = new CommonResponse<ContactDeleteResponse>();
            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                   new MySqlParameter("@SPid", MySqlDbType.Int32) {Value = objRequest.ID }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "DeleteContact", ds, TableName, parameters);

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
