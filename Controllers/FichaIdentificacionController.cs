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

        [HttpGet ("hospitalBoca/notasMedicas/paciente")]
        public IActionResult getAllNotasMedicas([FromBody] int numFicha)
        {
            try
            {
                var res = service.getAllNotasMedicas(numFicha);
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/notasMedicas/save")]
        public IActionResult saveNotaMedica([FromBody] Notamedica nm)
        {
            try
            {
                service.saveNotaMedica(nm);   
                return Ok(nm);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
    }
}