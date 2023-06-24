using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    [Route("hospitalBoca/catalogos")]
    public class CatalogosController : ControllerBase
    {
        private readonly IServiceCatalogos service;

        public CatalogosController(IServiceCatalogos service)
        {
            this.service = service;
        }

        [HttpGet ("calidadRelacion")]
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

        [HttpGet ("calidadServicio")]
        public IActionResult getAllCalidadServicio()
        {
            try
            {
                var res = service.getAllCalidadServicio();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("escolaridad")]
        public IActionResult getAllEscolaridad()
        {
            try
            {
                var res = service.getAllEscolaridad();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("estadoCivil")]
        public IActionResult getAllEstadoCivil()
        {
            try
            {
                var res = service.getAllEstadoCivil();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("lugarReferencia")]
        public IActionResult getAllLugarReferencia()
        {
            try
            {
                var res = service.getAllLugarReferencia();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("metodoPlanificacion")]
        public IActionResult getAllMetodoPlanificacion()
        {
            try
            {
                var res = service.getAllMetodoPlanificacion();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("ocupacion")]
        public IActionResult getAllOcupacion()
        {
            try
            {
                var res = service.getAllOcupacion();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("opinionPareja")]
        public IActionResult getAllOpinionPareja()
        {
            try
            {
                var res = service.getAllOpinionPareja();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        [HttpGet ("religion")]
        public IActionResult getAllReligion()
        {
            try
            {
                var res = service.getAllReligion();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
    }
}