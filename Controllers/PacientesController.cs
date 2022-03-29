using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class PacientesController : ControllerBase
    {
        private readonly IServicePacientes service;
        public PacientesController(IServicePacientes service)
        {
            this.service = service;
        }


        [HttpGet ("hospitalBoca/pacientes/all")]
        public IActionResult getAll()
        {
            var res = service.getAll();
            return Ok(res);
        }

        [HttpPost ("hospitalBoca/pacientes/save")]
        public IActionResult savePaciente([FromBody] Paciente p) 
        {
            try
            {
                service.savePaciente(p);
                return Ok (true);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost ("hospitalBoca/pacientes/update")]
        public IActionResult updatePaciente([FromBody] Paciente p)
        {
            try
            {
                service.updatePaciente(p);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/pacientes/delete")]
        public IActionResult deletePaciente([FromBody] string numExpediente)
        {
            try
            {
                service.deletPaciente(numExpediente);
                return Ok(true);
            }
            catch (System.Exception)
            {   
                throw;
            }
        }
    }
}
