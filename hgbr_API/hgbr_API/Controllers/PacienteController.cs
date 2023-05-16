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


        [HttpGet("{numExpediente}")]
        public object getPaciente(string numExpediente)
        {
            try
            {

                var res = _service.getPaciente(numExpediente);
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

        [HttpPost("update")]
        public IActionResult updatePaciente([FromBody] Paciente paciente)
        {
            try
            {
                _service.updatePaciente(paciente);
                return Ok();
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("delete")]
        public IActionResult deletePaciente([FromBody] string numExpediente)
        {
            try
            {

                _service.deletePaciente(numExpediente);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}