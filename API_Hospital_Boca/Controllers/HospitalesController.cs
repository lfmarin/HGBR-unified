using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class HospitalesController : ControllerBase
    {
        private readonly IServiceHospitales service;

        public HospitalesController(IServiceHospitales service)
        {
            this.service = service;
        }

        [HttpGet ("hospitalBoca/hospitales/all")]
        public IActionResult getAll()
        {
            try
            {
                var res = service.getAll();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/hospitales/save")]
        public IActionResult saveHospital([FromBody] Hospitale hos)
        {
            try
            {
                service.saveHospital(hos);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}