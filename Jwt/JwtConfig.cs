using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace ASG_ADAC_FE.Jwt
{
    public class JwtConfig
    {
        private readonly string _secret;
        private readonly string _issuer;

        public JwtConfig(IConfiguration config)
        {
           
            _secret = config["Jwt:Key"];
            _issuer = config["Jwt:Issuer"];
        }

        public string GenerateSecurityToken(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_issuer,
              _issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
          

        }
    }
}
