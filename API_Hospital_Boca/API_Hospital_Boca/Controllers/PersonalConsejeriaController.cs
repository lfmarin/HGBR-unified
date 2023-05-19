using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Controllers
{
    [Route("hospitalBoca/personalConsejeria")]
    public class PersonalConsejeriaController : ControllerBase
    {
        private readonly IServicePersonalConsejeria service;

        public PersonalConsejeriaController(IServicePersonalConsejeria service)
        {
            this.service = service;
        }

        [HttpGet ("all")]
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

        [HttpPost ("save")]
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

        [HttpGet ("{idPersonal}")]
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

        [HttpPost ("update")]
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