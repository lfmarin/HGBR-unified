using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    [Route("hospitalBoca/historiaClinica")]
    public class HistoriaclinicaController : ControllerBase
    {
        private readonly IServiceHistoriaClinica service;

        public HistoriaclinicaController (IServiceHistoriaClinica service)
        {
            this.service = service;
        }

        [HttpPost ("save")]
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

        [HttpPost ("motivoSolicitud/save")]
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

        [HttpPost ("motivoSolicitud/update")]
        public IActionResult updateMotivoSolicitud([FromBody] Motivosolicitud ms)
        {
            try
            {
                service.updateMotivoSolicitud(ms);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("historiaExploracion/save")]
        public IActionResult saveHistoriaExploracion([FromBody] Historiaexploracion he)
        {
            try
            {
                service.saveHistoriaExploracion(he);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("historiaExploracion/update")]
        public IActionResult updateHistoriaExploracion([FromBody] Historiaexploracion he)
        {
            try
            {
                service.updateHistoriaExploracion(he);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("procedimientoQuirurgico/save")]
        public IActionResult saveProcedimientoQuirurgico([FromBody] Procquirurgico pq)
        {
            try
            {
                service.saveProcedimientoQuirurgico(pq);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("procedimientoQuirurgico/update")]
        public IActionResult updateProcedimientoQuirurgico([FromBody] Procquirurgico pq)
        {
            try
            {
                service.updateProcedimeintoQuirurgico(pq);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("estudioAnatomo/save")]
        public IActionResult saveEstudioAnatomo([FromBody] Estudioanatomo ea)
        {
            try
            {
                service.saveEstudioAnatomo(ea);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("estudioAnatomo/update")]
        public IActionResult updateEstudioAnatomoo([FromBody] Estudioanatomo ea)
        {
            try
            {
                service.updateEstudioAnatomo(ea);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("evolucion/save")]
        public IActionResult saveEvolucion([FromBody] Evolucion ev)
        {
            try
            {
                service.saveEvolucion(ev);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("evolucion/update")]
        public IActionResult updateEvolucion([FromBody] Evolucion ev)
        {
            try
            {
                service.updateEvolucion(ev);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("{numExp}")]
        public IActionResult getHistoriaByNumExp(string numExp)
        {
            try
            {
                var res = service.getHistoriaByNumExp(numExp);
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("motivoSolicitud/{idHistoria}")]
        public IActionResult getMotivoSolicitudByIdHist(int idHistoria)
        {
            try
            {
                var res = service.getMotivoSolicitudByIdHist(idHistoria);
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("historiaExploracion/{idHistoria}")]
        public IActionResult gethistoriaExploracionByIdHist(int idHistoria)
        {
            try
            {
                var res = service.getHistoriaexploracionByIdHist(idHistoria);
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("procedimientoQuirurgico/{idHistoria}")]
        public IActionResult getProcedimientoQuirurgico(int idHistoria)
        {
            try
            {
                var res = service.getProcedimientoQuirurgicoByIdHist(idHistoria);
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("EstudioAnatomo/{idHistoria}")]
        public IActionResult getEstudioAnatomoByIdHsit(int idHistoria)
        {
            try
            {
                var res = service.getEstudioAnatomo(idHistoria);
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet ("evolucion/{idHistoria}")]
        public IActionResult getEvolucionByIdHsit(int idHistoria)
        {
            try
            {
                var res = service.getEvolucionByIdHist(idHistoria);
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

}