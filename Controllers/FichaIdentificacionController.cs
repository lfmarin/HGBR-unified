using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class FichaIdentificacionController : ControllerBase
    {
        private readonly IServiceFichaIdentificacion service;

        public FichaIdentificacionController(IServiceFichaIdentificacion service)
        {
            this.service = service;
        }

        [HttpPost ("hospitalBoca/fichaIdent/update")]
        public IActionResult updateFichaIndet([FromBody] Fichaidentificacion fi)
        {
            try
            {
                service.updateFichaIdentificacion(fi);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}