using com.adtek.br.Dtos;
using com.adtek.br.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace com.adtek.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly TokenService tokenService;

        public TokenController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post(UserInfo userInfo)
        {
            return Ok(this.tokenService.autho(userInfo));
        }
    }
}
