using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;
using API_Hospital_Boca.Bussiness;
using Microsoft.AspNetCore.Authorization;

namespace API_Hospital_Boca.Controllers
{
    public class PacientesController : ControllerBase
    {
        private readonly IServicePacientes service;
        private readonly IServiceHistoriaClinica serviceHistoria;
        private readonly IServiceFichaIdentificacion serviceFicha;
        private readonly IServiceEncuestaSeguimeinto serviceEncuesta;
        private readonly IServiceNotaMedica serviceNotaMedica;
        public PacientesController(IServicePacientes service, IServiceHistoriaClinica serviceHistoria, 
                                    IServiceFichaIdentificacion serviceFicha, IServiceEncuestaSeguimeinto serviceEncuesta,
                                    IServiceNotaMedica notaMedica)
        {
            this.service = service;
            this.serviceHistoria = serviceHistoria;
            this.serviceFicha = serviceFicha;
            this.serviceEncuesta = serviceEncuesta;
            this.serviceNotaMedica = notaMedica;
        }


        [Authorize]
        [HttpGet ("hospitalBoca/pacientes/all")]
        public IActionResult getAll()
        {
            var res = service.getAll();
            return Ok(res);
        }

        [Authorize]
        [HttpPost ("hospitalBoca/pacientes/save")]
        public IActionResult savePaciente([FromBody] NuevoPaciente np) 
        {
            try
            {
                service.savePaciente(np.paciente);

                var hist = new Historiaclinica();
                hist.FkPaciente = np.paciente.NoExpediente;
                hist.FkHospital = np.hospital;
                hist.FechaElab = System.DateTime.Today;
                serviceHistoria.saveHistoriaClinica(hist);

                int lastId = ((ServiceHistoriaClinica) serviceHistoria).getLastId();

                var aux = new Motivosolicitud();
                aux.FkHistoria = lastId;
                serviceHistoria.saveMotivoSolicitud(aux);

                var aux2 = new Historiaexploracion();
                aux2.FkHistoria = lastId;
                serviceHistoria.saveHistoriaExploracion(aux2);

                var aux3 = new Procquirurgico();
                aux3.FkHistoria = lastId;
                serviceHistoria.saveProcedimientoQuirurgico(aux3);

                var aux4 = new Estudioanatomo();
                aux4.FkHistoria = lastId;
                serviceHistoria.saveEstudioAnatomo(aux4);

                var aux5 = new Evolucion();
                aux5.FkHistoria = lastId;
                serviceHistoria.saveEvolucion(aux5);

                var aux6 = new Fichaidentificacion();
                aux6.FkPaciente = np.paciente.NoExpediente;
                serviceFicha.saveFichaIdentificacion(aux6);

                serviceFicha.saveCartaConsentimiento(new Cartaconsentimiento(), np.paciente.NoExpediente);

                var aux7 = new Encuestaseguimiento();
                aux7.FkPaciente = np.paciente.NoExpediente;
                serviceEncuesta.saveEncuestaSeguimeinto(aux7);

                var aux8 = new Notamedica();
                aux8.FkFicha = ((ServiceFichaIdentificacion) serviceFicha).getLastFichaId();
                serviceNotaMedica.saveNotaMedica(aux8);

                return Ok (true);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [Authorize]
        [HttpPost ("hospitalBoca/pacientes/update")]
        public IActionResult updatePaciente([FromBody] Paciente p)
        {
            try
            {
                service.updatePaciente(p);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost ("hospitalBoca/pacientes/delete")]
        public IActionResult deletePaciente([FromBody] string numExpediente)
        {
            try
            {
                service.deletPaciente(numExpediente);
                return Ok(true);
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        [Authorize]
        [HttpGet ("hospitalBoca/pacientes/{numExpediente}")]
        public IActionResult getPaciente(string numExpediente)
        {
            var info = service.getPaciente(numExpediente);
            if (info != null)
                return Ok(info);return Ok(info);
        }
    }

    public class NuevoPaciente
    {
        public Paciente paciente { get; set; }
        public int hospital { get; set; }
    }
}
