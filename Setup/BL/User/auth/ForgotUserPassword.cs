using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using ZstdSharp;
using Setup.Request.Admin.auth;

namespace Setup.BL.User.auth
{
    public class ForgotUserPassword : IForgotUserPassword
    {
        #region Common Data
        private readonly IConfiguration _configuration;
        private readonly DataAccessClass dataAccess;
        private readonly CommonMethod commonMethod;

        public ForgotUserPassword(IConfiguration config)
        {
            _configuration = config;
            dataAccess = new DataAccessClass(_configuration);
            commonMethod = new CommonMethod(_configuration);
        }
        #endregion

        public CommonResponse<ForgotUserPasswordResponse> ForgotUserPasswords(ForgotUserPasswordRequest objRequest)
        {
            CommonResponse<ForgotUserPasswordResponse> response = new CommonResponse<ForgotUserPasswordResponse>();

            try
            {
                Random random = new Random();
                int otpValue = random.Next(100000, 999999);
                string generatedOTP = otpValue.ToString();

                string email = objRequest.Email;
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("anuragsaini2200@gmail.com", "xful yrmo dvkq yxym");
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("anuragsaini2200@gmail.com", "Zordik"),
                        Subject = "Password Reset OTP",
                        Body = $"We have received a request to reset the password for your Account.\n" +
                          $"To proceed with this request, we have generated a one-time password (OTP) for you. Please use the following OTP to complete the password reset process:\n\n" +
                         $"OTP: {generatedOTP}\n\n" +
                          $"Please note that this OTP is valid for the next 10 minutes. If you do not use it within this timeframe, you will need to submit another password reset request.\n\n" +
                          $"\n\nBest Regards,\\Zordik."
                    };

                    // Add recipient
                    mailMessage.To.Add(email)
;
                    try
                    {
                        // Send the email
                        smtpClient.Send(mailMessage);

                        string jsonString = JsonConvert.SerializeObject("otp : " + generatedOTP);
                        response.ResponseCode = 1;
                        response.ResponseMessage = "OTP Sent Successfully";
                    }
                    catch (SmtpException ex)
                    {
                        // Handle SMTP exceptions
                        response.ResponseCode = -1;
                        response.ResponseMessage = $"SMTP error: {ex.Message}";
                    }
                    catch (Exception ex)
                    {
                        // Handle other exceptions
                        response.ResponseCode = -1;
                        response.ResponseMessage = $"Error: {ex.Message}";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                response.ResponseCode = -1;
                response.ResponseMessage = $"Error: {ex.Message}";
            }
            return response;
        }
    }
}
