using com.adtek.br.Dtos;
using com.adtek.br.Services;
using Microsoft.AspNetCore.Mvc;

namespace com.adtek.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : MainController
    {

        private readonly UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<UsuarioDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioDto>> Crear(UsuarioDto usuarioDto)
        {
            
            return await this.RespuestaAsync(this.usuarioService.Crear(usuarioDto));
        }

    }
}
