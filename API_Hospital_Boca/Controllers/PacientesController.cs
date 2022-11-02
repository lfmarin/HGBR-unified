using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;
using API_Hospital_Boca.Bussiness;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace API_Hospital_Boca.Controllers
{
    // Este valor define el lugar donde será aplicado en el API.
    // Ejemplo: con "all": hospitalBoca/pacientes/all.
    [Route("hospitalBoca/pacientes")]
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
        [HttpGet ("all")]
        public IActionResult getAll()
        {
            var res = service.getAll();
            return Ok(res);
        }

        [Authorize]
        [HttpGet("{numExpediente}")]
        public IActionResult getPaciente(string numExpediente)
        {
            var info = service.getPaciente(numExpediente);
            if (info != null)
                return Ok(info);
            return NotFound();
        }

        [Authorize]
        [HttpPost ("consentimiento")]
        public async Task<ActionResult> generarConsentimiento([FromBody] InfoConsentimiento infoCons)
        {
            try
            {
                Paciente info = service.getClassPaciente(infoCons.pacienteID);

                if (info == null)
                {
                    Console.WriteLine("No encuentro el paciente con el ID " + infoCons.pacienteID);
                    return NotFound();
                }

                var nombre = info.Nombre;
                var apMate = info.ApMaterno;
                var apPate = info.ApPaterno;
                var Famil1 = infoCons.fam1;
                var Famil2 = infoCons.fam2;
                var Doct = infoCons.doc;
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = $"/bin/sh";
                // psi.WorkingDirectory = "/Users/joseluis/docsh/";
                psi.WorkingDirectory = "./docsh/";
                psi.Arguments = "-c \"pwd\"";
                // Crea el comando para correr la aplicación.
                psi.Arguments = "-c \"./constancia.sh '" + nombre + " " + apMate + " " + apPate + "' " + infoCons.pacienteID
                    + " '"+Famil1+"' '" + Famil2 + "' '" + Doct + "' \"";
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                Process proc = new Process
                {
                    StartInfo = psi
                };

                proc.Start();

                string error = proc.StandardError.ReadToEnd();

                string output = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();

                string createdFileName = $"./docsh/gen/const_{infoCons.pacienteID}.pdf";
                Response.Headers.ContentDisposition.Append("inline; filename="+ createdFileName);
                var bytes = await System.IO.File.ReadAllBytesAsync(createdFileName);
                return File(bytes, "application/pdf", "constancia.pdf");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost ("save")]
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
        [HttpPost ("update")]
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
        [HttpPost ("delete")]
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
    }

    public class NuevoPaciente
    {
        public Paciente paciente { get; set; }
        public int hospital { get; set; }
    }

    public class InfoConsentimiento
    {
        public string pacienteID { get; set; }
        public string fam1 { get; set; }
        public string fam2 { get; set; }
        public string doc { get; set; }
    }
}
