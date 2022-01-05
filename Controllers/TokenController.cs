using ASG_ADAC_FE.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ASG_ADAC_FE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string GetRandomToken()
        {
            var jwt = new JwtConfig(_config);
            var token = jwt.GenerateSecurityToken("admin@allowtoaccess.com");
            return token;
        }
    }
}
