using Domain.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context.Error is Domain.Exceptions.ValidationException ex)
            {
                Logger.Log(context.Error, "VALIDATION");
                return BadRequest(new
                {
                    message = context.Error?.Message,
                    code = ex.Code
                });
            }
            if (context.Error is Domain.Exceptions.NotFoundException)
            {
                Logger.Log(context.Error, "NOTFOUND");
                return NotFound(new
                {
                    message = context.Error?.Message,
                });
            }
            Logger.Log(context.Error, "ERROR");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new
                {
                    message = context.Error?.Message,
                    detail = context.Error?.StackTrace
                });
        }
    }
}
