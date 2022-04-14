using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class DoctoresController : ControllerBase
    {
        private readonly IServiceDoctores service;
        public DoctoresController(IServiceDoctores service)
        {
            this.service = service;
        }


        [HttpGet ("hospitalBoca/doctores/all")]
        public IActionResult getAll()
        {
            var res = service.getAll();
            return Ok(res);
        }

        [HttpPost ("hospitalBoca/doctores/save")]
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

        [HttpPost ("hospitalBoca/doctores/update")]
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

        [HttpPost ("hospitalBoca/doctores/delete")]
        public IActionResult deleteDoctor([FromBody] int idDoctor)
        {
            try
            {
                service.deleteDoctor(idDoctor);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("hospitalBoca/doctores/getOne")]
        public IActionResult getDoctor([FromBody] int idDoctor)
        {
            try
            {
                var doc = service.getDoctor(idDoctor);
                return Ok(doc);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}