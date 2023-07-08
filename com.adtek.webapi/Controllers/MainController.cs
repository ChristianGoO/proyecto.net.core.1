using com.adtek.br.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace com.adtek.webapi.Controllers
{
    public class MainController : ControllerBase
    {

        protected Task<ObjectResult> RespuestaAsync<T>(Result<T> result)
        {
            return Task.Run (() =>
            {
                return this.StatusCode(result.Codigo, result);
            });
        }
    }
}
