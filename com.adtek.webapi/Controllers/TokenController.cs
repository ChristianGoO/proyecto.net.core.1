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
    public class TokenController : MainController
    {
        private readonly TokenService tokenService;

        public TokenController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<TokenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TokenDto>> Post(UserInfo userInfo)
        {
            return await this.RespuestaAsync(this.tokenService.autho(userInfo));
        }
    }
}
