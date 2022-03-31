using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class CatalogosController : ControllerBase
    {
        private readonly IServiceCatalogos service;

        public CatalogosController(IServiceCatalogos service)
        {
            this.service = service;
        }

        [HttpGet ("hospitalBoca/catalogos/calidadRelacion")]
        public IActionResult getAllCalidadRelacion()
        {
            try
            {
                var res = service.getAllCalidadRelacion();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}