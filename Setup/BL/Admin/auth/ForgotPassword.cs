using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.Admin.auth;
using Setup.Request.Admin.auth;
using Setup.Response.Admin.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using ZstdSharp;
using Org.BouncyCastle.Asn1.Ocsp;


namespace Setup.BL.Admin.auth
{
    public class ForgotPassword : IForgotPassword
    {
        #region Common Data
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;
        private readonly CommonMethod commonMethod;

        public ForgotPassword(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
            commonMethod = new CommonMethod(_configuration);
        }
        #endregion

        public CommonResponse<ForgotPasswordResponse> ForgotAdminPassword(ForgotPasswordRequest objRequest)
        {
            CommonResponse<ForgotPasswordResponse> response = new CommonResponse<ForgotPasswordResponse>();

            try
            {
                #region Parameters
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@SPEmailId", MySqlDbType.String) {Value = objRequest.EmailId }
                };
                #endregion

                DataSet ds = new DataSet();
                string[] TableName = { "Response", "Data" };
                dataAccess.ExecuteQuery(CommandType.StoredProcedure, "CheckAdminEmailExist", ds, TableName, parameters);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    response.ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);

                    if (response.ResponseCode == 1 && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        string? sender_Email = Convert.ToString(ds.Tables[1].Rows[0]["sender_email"]);
                        string? sender_Email_Password = Convert.ToString(ds.Tables[1].Rows[0]["sender_email_password"]);
                        string? sender_Name = Convert.ToString(ds.Tables[1].Rows[0]["sender_name"]);
                        string? smtp = Convert.ToString(ds.Tables[1].Rows[0]["smtp"]);
                        int port = Convert.ToInt32(ds.Tables[1].Rows[0]["port"]);

                        Random random = new Random();
                        int otpValue = random.Next(100000, 999999);
                        string generatedOTP = otpValue.ToString();

                        string? email = objRequest.EmailId;
                        using (SmtpClient smtpClient = new SmtpClient(smtp, port))
                        {
                            smtpClient.Credentials = new NetworkCredential(sender_Email, sender_Email_Password);
                            smtpClient.EnableSsl = true;

                            MailMessage mailMessage = new MailMessage
                            {
                                From = new MailAddress(sender_Email, sender_Name),
                                Subject = "Password Reset OTP",
                                Body = $"We have received a request to reset the password for your Account.\n" +
                                  $"To proceed with this request, we have generated a one-time password (OTP) for you. Please use the following OTP to complete the password reset process:\n\n" +
                                 $"OTP: {generatedOTP}\n\n" +
                                  $"Please note that this OTP is valid for the next 10 minutes. If you do not use it within this timeframe, you will need to submit another password reset request.\n\n" +
                                  $"\n\nBest Regards,\\Zordik."
                            };

                            // Add recipient
                            mailMessage.To.Add(email);
                            try
                            {
                                smtpClient.Send(mailMessage);
                                string jsonString = JsonConvert.SerializeObject("OTP : " + generatedOTP);
                                response.ResponseData = jsonString;
                                response.ResponseCode = 1;
                                response.ResponseMessage = "OTP Sent Successfully";
                            }
                            catch (SmtpException ex)
                            {
                                response.ResponseCode = -1;
                                response.ResponseMessage = $"SMTP error: {ex.Message}";
                            }
                            catch (Exception ex)
                            {
                                response.ResponseCode = -1;
                                response.ResponseMessage = $"Error: {ex.Message}";
                            }
                        }
                    }
                    else
                    {
                        response.ResponseCode = 0;
                        response.ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                        response.ResponseData = null;
                    }
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