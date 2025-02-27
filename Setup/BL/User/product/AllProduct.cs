﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.product;
using Setup.Request.User.product;
using Setup.Response.User.product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.BL.User.product
{
    public class AllProduct : IAllProduct
    {
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass _dataAccessClass;

        public AllProduct(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataAccessClass = new DataAccessClass(_configuration);
        }

        public CommonResponse<AllProductResponse> GetAllProduct(AllProductRequest objRequest)
        {
            CommonResponse<AllProductResponse> response = new CommonResponse<AllProductResponse>();

            try
            {
                //string query = "";

                //if (objRequest.Categories != null && objRequest.Categories.Count > 0)
                //{
                //    query += "AND p.cat_id IN (" + string.Join(",", objRequest.Categories) + ")";
                //}

                //if (objRequest.Subcategories != null && objRequest.Subcategories.Count > 0)
                //{
                //    query += "AND p.sub_cat_id IN (" + string.Join(",", objRequest.Subcategories) + ")";
                //}
                //if (objRequest.Colors != null && objRequest.Colors.Count > 0)
                //{
                //    query += " AND c.id IN ('" + string.Join("','", objRequest.Colors) + "')";
                //}
                //if (objRequest.Sizes != null && objRequest.Sizes.Count > 0)
                //{
                //    query += " AND SizeID IN ('" + string.Join("','", objRequest.Sizes) + "')";
                //}
                //if (objRequest.MinPrice.HasValue)
                //{
                //    query += " AND Price >= " + objRequest.MinPrice.Value;
                //} 
                //if (objRequest.MaxPrice.HasValue)
                //{
                //    query += " AND Price <= " + objRequest.MaxPrice.Value;
                //}




                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPLimit", MySqlDbType.Int32) {Value = objRequest.Limit }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Records" };
                _dataAccessClass.ExecuteQuery(CommandType.StoredProcedure, "GetAllProduct", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (response.ResponseCode != 0 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string jsonData = JsonConvert.SerializeObject(ds.Tables[1]);
                        response.ResponseData = jsonData;
                        response.Token = null;
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.ResponseMessage = "No Record To Display!";
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
