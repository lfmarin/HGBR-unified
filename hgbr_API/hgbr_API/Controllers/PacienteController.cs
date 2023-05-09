using Microsoft.AspNetCore.Mvc;
using hgbr_API.Interfaces;
using hgbr_API.Models;

namespace API_Hospital_Boca.Controllers
{
    [Route("hgbr_api/paciente")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteServices _service;

        public PacienteController(IPacienteServices service)
        {
            this._service = service;
        }

        [HttpGet("all")]
        public IActionResult getAll()
        {
            try
            {
                var res = _service.getAll();
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("save")]
        public IActionResult savePaciente([FromBody] Paciente paciente)
        {
            try
            {
                _service.savePaciente(paciente);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}