using Microsoft.AspNetCore.Mvc;
using hgbr_API.Interfaces;
using hgbr_API.Models;

namespace hgbr_API.Controllers
{
    [Route("hgbr_api/admisiones")]
    public class AdmisionesController : ControllerBase
    {
        private readonly IAdmisionesServices _service;

        public AdmisionesController(IAdmisionesServices service)
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


        [HttpGet("{folio}")]
        public object getAdmisiones(int folio)
        {
            try
            {

                var res = _service.getAdmisiones(folio);
                return Ok(res);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost("save")]
        public IActionResult saveAdmisiones([FromBody] Admisione admision)
        {
            try
            {
                _service.saveAdmisiones(admision);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("update")]
        public IActionResult updateAdmisiones([FromBody] Admisione admision)
        {
            try
            {
                _service.updateAdmisiones(admision);
                return Ok();
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("delete")]
        public IActionResult deleteAdmisiones([FromBody] int folio)
        {
            try
            {

                _service.deleteAdmisiones(folio);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}