using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Setup.DAL;
using Setup.ITF.Admin.category;
using Setup.Request.Admin.category;
using Setup.Response.Admin.category;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.category
{
    public class CategoryDelete : ICategoryDelete
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public CategoryDelete(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<CategoryDeleteResponse> DeleteCategory(CategoryDeleteRequest objRequest)
        {
            CommonResponse<CategoryDeleteResponse> response = new CommonResponse<CategoryDeleteResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                   new MySqlParameter("@SPCat_id", MySqlDbType.Int32) {Value = objRequest.ID }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "DeleteCategory", ds, TableName, parameters);

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
