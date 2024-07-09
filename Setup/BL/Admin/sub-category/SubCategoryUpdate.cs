using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Setup.DAL;
using Setup.ITF.Admin.sub_category;
using Setup.Request.Admin.sub_category;
using Setup.Response.Admin.sub_category;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.Admin.sub_category
{
    public class SubCategoryUpdate : ISubCategoryUpdate
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly DataAccessClass dataAccess;

        public SubCategoryUpdate(IConfiguration config, IWebHostEnvironment environment)
        {
            _configuration = config;
            _environment = environment;
            dataAccess = new DataAccessClass(_configuration);
        }

        public CommonResponse<SubCategoryUpdateResponse> UpdateSubCategory(SubCategoryUpdateRequest request)
        {
            CommonResponse<SubCategoryUpdateResponse> response = new CommonResponse<SubCategoryUpdateResponse>();

            try
            {
                #region Parameters

                MySqlParameter[] parameters = {
                new MySqlParameter("@SPSubCat_id", MySqlDbType.Int32) {Value = request.SubCategory_id },
                new MySqlParameter("@SPCat_id", MySqlDbType.Int32) {Value = request.Category_id },
                new MySqlParameter("@SPName", MySqlDbType.String) {Value = request.Name },
                new MySqlParameter("@SPSlug", MySqlDbType.String) {Value = request.Slug },
                new MySqlParameter("@SPStatus", MySqlDbType.Int32) {Value = request.Status }
                };

                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "UpdateSubCategory", ds, TableName, parameters);
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
