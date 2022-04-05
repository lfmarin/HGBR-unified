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
    }
}