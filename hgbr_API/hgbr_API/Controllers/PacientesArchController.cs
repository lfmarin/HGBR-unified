using Microsoft.AspNetCore.Mvc;
using hgbr_API.Interfaces;
using hgbr_API.Models;

namespace hgbr_API.Controllers
{
    [Route("hgbr_api/pacientes")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacientesArchServices _service;

        public PacienteController(IPacientesArchServices service)
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
        public object getPacientesarch(string numExpediente)
        {
            try
            {

                var res = _service.getPacientesarch(numExpediente);
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost("save")]
        public IActionResult savePacientesarch([FromBody] Pacientesarch paciente)
        {
            try
            {
                _service.savePacientesarch(paciente);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("update")]
        public IActionResult updatePacientesarch([FromBody] Pacientesarch paciente)
        {
            try
            {
                _service.updatePacientesarch(paciente);
                return Ok();
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("delete")]
        public IActionResult deletePacientesarch([FromBody] string numExpediente)
        {
            try
            {

                _service.deletePacientesarch(numExpediente);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}