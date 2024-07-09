using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Setup.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Setup
{
    public class CommonMethod
    {

        private readonly IConfiguration _configuration;

        public CommonMethod(IConfiguration config)
        {
            _configuration = config;
        }


        // Method to Generate the Token When User Successfully Login
        public string GenerateToken(string userEmail)
        {
            try
            {
                // Token Generation
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var claims = new List<Claim>
                  {
                       new Claim(ClaimTypes.Email, userEmail)
                  };

                var expires = DateTime.UtcNow.AddMinutes(1);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}