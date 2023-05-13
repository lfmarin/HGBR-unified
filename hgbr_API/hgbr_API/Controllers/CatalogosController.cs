using Microsoft.AspNetCore.Mvc;
using hgbr_API.Interfaces;
using hgbr_API.Models;

namespace hgbr_API.Controllers
{
    [Route("hgbr_api/catalogos")]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogosServices _service;

        public CatalogosController(ICatalogosServices service)
        {
            this._service = service;
        }

        [HttpGet("estadoConyugal")]
        public IActionResult getAllEstadoConyugal()
        {
            try
            {
                var res = _service.getAllEstadoConyugal();
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("tipoAsentamiento")]
        public IActionResult getAllTipoAsentamiento()
        {
            try
            {
                var res = _service.getAllTipoAsentamiento();
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("tipoVialidad")]
        public IActionResult getAllTipoVialidad()
        {
            try
            {
                var res = _service.getAllTipoVialidad();
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("sexo")]
        public IActionResult getAllSexo()
        {
            try
            {
                var res = _service.getAllSexo();
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("estado")]
        public IActionResult getAllEstado()
        {
            try
            {
                var res = _service.getAllEstado();
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}