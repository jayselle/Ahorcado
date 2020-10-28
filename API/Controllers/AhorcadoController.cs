using System;
using Microsoft.AspNetCore.Mvc;
using Application;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AhorcadoController : ControllerBase
    {
        private App _app;
        public AhorcadoController(App app)
        {
            _app = app;
        }

        [HttpPost("{letra}")]
        public ActionResult<GetJuegoRespuesta> Post(string letra)
        {
            try
            {
                var respuesta = _app.ArriesgarLetra(letra);
                
                return Ok(respuesta.Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}