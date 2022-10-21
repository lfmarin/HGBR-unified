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

        [HttpGet ("hospitalBoca/catalogos/calidadServicio")]
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
        
        [HttpGet ("hospitalBoca/catalogos/escolaridad")]
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
        
        [HttpGet ("hospitalBoca/catalogos/estadoCivil")]
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
        
        [HttpGet ("hospitalBoca/catalogos/lugarReferencia")]
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
        
        [HttpGet ("hospitalBoca/catalogos/metodoPlanificacion")]
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
        
        [HttpGet ("hospitalBoca/catalogos/ocupacion")]
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
        
        [HttpGet ("hospitalBoca/catalogos/opinionPareja")]
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
        
        [HttpGet ("hospitalBoca/catalogos/religion")]
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