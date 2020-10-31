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

        [HttpGet]
        public ActionResult<string> GetModelo()
        {
            var respuesta = _app.GetModelo();

            return Ok(respuesta);
        }

        [HttpPost]
        public ActionResult<GetJuegoRespuesta> ArriesgarLetra([FromBody] GetJuegoPedido pedido)
        {
            try
            {
                var respuesta = _app.ArriesgarLetra(pedido.letra);
                
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}