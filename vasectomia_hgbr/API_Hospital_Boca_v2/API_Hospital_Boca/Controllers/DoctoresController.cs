using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_Hospital_Boca.Controllers
{
    [Route("hospitalBoca/doctores")]
    public class DoctoresController : ControllerBase
    {
        private readonly IServiceDoctores service;
        public DoctoresController(IServiceDoctores service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet ("all")]
        public IActionResult getAll()
        {
            var res = service.getAll();
            return Ok(res);
        }

        [Authorize(Roles = "Admin,Coordinador")]
        [HttpPost ("save")]
        public IActionResult saveDoctor([FromBody] Doctore d)
        {
            try
            {
                service.saveDoctor(d);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "Admin,Coordinador")]
        [HttpPost ("update")]
        public IActionResult updateDoctor([FromBody] Doctore d)
        {
            try
            {
                service.updateDoctor(d);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "Admin,Coordinador")]
        [HttpPost ("delete")]
        public IActionResult deleteDoctor([FromBody] int idDoctor)
        {
            try
            {
                service.deleteDoctor(idDoctor);
                return Ok(true);
            }
            // TODO: ¡Marcar las excepciones especificas para declarar cada tipo
            // de resultado!
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet ("{idDoctor}")]
        [Authorize(Roles = "Admin,Coordinador")]
        public IActionResult getDoctor(int idDoctor)
        {
            try
            {
                var doc = service.getDoctor(idDoctor);
                return Ok(doc);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}