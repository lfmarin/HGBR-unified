using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class FichaIdentificacionController : ControllerBase
    {
        private readonly IServiceFichaIdentificacion service;
        private readonly IServiceNotaMedica serviceNota;

        public FichaIdentificacionController(IServiceFichaIdentificacion service, IServiceNotaMedica serviceNota)
        {
            this.service = service;
            this.serviceNota = serviceNota;
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

        [HttpGet ("hospitalBoca/CartaConsentimiento/{numExp}")]
        public IActionResult getCartaConsentimiento(string numExp)
        {
            try
            {
                var res = this.service.getCartaConsentimiento(numExp);
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/CartaConsentimiento/update")]
        public IActionResult updateCartaConsentimiento([FromBody] Cartaconsentimiento cc)
        {
            try
            {
                this.service.updateCartaConsentimiento(cc);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("hospitalBoca/NotaMedica/{numExp}")]
        public IActionResult getNotaMedicaByIdFicha(string numExp)
        {
            try
            {
                var nota = serviceNota.getNotaMedicaByNumExp(numExp); 
                return Ok(nota);  
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/NotaMedica/update")]
        public IActionResult updateNotaMedica([FromBody] Notamedica notamedica)
        {
            try
            {
                serviceNota.updateNotaMedica(notamedica);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
    }
}