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
        private readonly string _expDate;
        private readonly string _issuer;

        public JwtConfig(IConfiguration config)
        {
            // _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            // _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
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

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.Email, email)
            //    }),
            //    Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            //return tokenHandler.WriteToken(token);

        }
    }
}
