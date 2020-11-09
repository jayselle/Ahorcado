using Microsoft.AspNetCore.Mvc;
using Application;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private App _app;
        public ConfigController(App app)
        {
            _app = app;
        }

		[HttpGet]
        public ActionResult<GetJuegoRespuesta> GetJuego()
        {
            var respuesta = _app.GetJuego();

            return Ok(respuesta.Result);
        }

        [HttpPost]
        public ActionResult<GetJuegoRespuesta> ResetJuego()
        {
            var respuesta = _app.ResetJuego();

            return Ok(respuesta.Result);
        }
    }
}