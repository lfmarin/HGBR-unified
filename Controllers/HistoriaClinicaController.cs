using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class HistoriaclinicaController : ControllerBase
    {
        private readonly IServiceHistoriaClinica service;

        public HistoriaclinicaController (IServiceHistoriaClinica service)
        {
            this.service = service;
        }

        [HttpPost ("hospitalBoca/historiaClinica/save")]
        public IActionResult saveHistoriaClinca([FromBody] Historiaclinica hc)
        {
            try
            {
                service.saveHistoriaClinica(hc);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/historiaClinica/motivoSolicitud/save")]
        public IActionResult saveMotivoSolicitud([FromBody] Motivosolicitud ms)
        {
            try
            {
                service.saveMotivoSolicitud(ms);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/historiaClinica/motivoSolicitud/update")]
        public IActionResult updateMotivoSolicitud([FromBody] Motivosolicitud ms)
        {
            try
            {
                System.Console.WriteLine(ms.FkHistoria);
                service.updateMotivoSolicitud(ms);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

}