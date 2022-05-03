using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    public class PersonalConsejeriaController : ControllerBase
    {
        private readonly IServicePersonalConsejeria service;

        public PersonalConsejeriaController(IServicePersonalConsejeria service)
        {
            this.service = service;
        }

        [HttpGet ("hospitalBoca/personalConsejeria/all")]
        public IActionResult getAllPersonalConsejeria()
        {
            try
            {
                var res = service.getAllPersonalConsejeria();
                return Ok(res);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/personalConsejeria/save")]
        public IActionResult savePersonalConsejeria([FromBody] Personalconsejerium pc)
        {
            try
            {
                service.savePersonalConsejeria(pc);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("hospitalBoca/personalConsejeria/{idPersonal}")]
        public IActionResult getOnePersonalConsejeria(int idPersonal)
        {
            try
            {
                var perso = service.getOnePersonalConsejeria(idPersonal);
                return Ok(perso);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost ("hospitalBoca/personalConsejeria/update")]
        public IActionResult updatePersonalConsejeria([FromBody] Personalconsejerium pc)
        {
            try
            {
                service.updatePersonalConsejeria(pc);
                return Ok(true);   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}