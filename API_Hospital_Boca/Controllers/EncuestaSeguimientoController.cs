using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class EncuestaSeguimientoController : ControllerBase
    {
        private readonly IServiceEncuestaSeguimeinto service;

        public EncuestaSeguimientoController( IServiceEncuestaSeguimeinto service)
        {
            this.service = service;
        }

        [HttpGet ("hospitalBoca/EncuestaSeguimiento/{numExp}")]
        public IActionResult getEncuestaByNumExp(string numExp)
        {
            try
            {
                var res = service.getEncuestaSeguimientoByNumExp(numExp);
                return Ok(res);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost ("hospitalBoca/EncuestaSeguimiento/update")]
        public IActionResult updateEncuestaSeg([FromBody] Encuestaseguimiento es)
        {
            try
            {
                service.updateEncuestaSeguimiento(es);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}