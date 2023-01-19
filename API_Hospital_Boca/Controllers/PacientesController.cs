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
        private readonly IServiceDoctores serviceDoctor;
        private readonly IServicePersonalConsejeria serviceConsejeria;
        public PacientesController(IServicePacientes service, IServiceHistoriaClinica serviceHistoria, 
                                    IServiceFichaIdentificacion serviceFicha, IServiceEncuestaSeguimeinto serviceEncuesta,
                                    IServiceNotaMedica notaMedica, IServiceDoctores serviceDoctor,
                                    IServicePersonalConsejeria serviceConsejeria)
        {
            this.service = service;
            this.serviceHistoria = serviceHistoria;
            this.serviceFicha = serviceFicha;
            this.serviceEncuesta = serviceEncuesta;
            this.serviceNotaMedica = notaMedica;
            this.serviceDoctor = serviceDoctor;
            this.serviceConsejeria = serviceConsejeria;
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

                var tiempoMes = DateTime.Now.ToString("MMMM");
                // Doctores y Personal son llaves foráneas, asi que hay que obtener los valores.
                Doctore doc = serviceDoctor.getClassDoctor( infoCons.doc );
                Personalconsejerium pc = serviceConsejeria.getClassPersonalConsejeria( infoCons.personal );
                // Console.WriteLine( infoCons.personal );
                // Console.WriteLine( infoCons.doc );

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = $"/bin/sh";
				psi.WorkingDirectory = "./";

				// Crea el comando para correr la aplicación.
                string proc_Str = $"-c \"./constancia.sh --NOMPACIENTE '{info.NombreCompleto}' \\";
                proc_Str += $"--IDPACIENTE '{infoCons.pacienteID}' \\";
                proc_Str += $"--TESTIGO1 '{infoCons.fam1}' \\";
                proc_Str += $"--TESTIGO2 '{infoCons.fam2}' \\";
                proc_Str += $"--PERSONAL '{pc.NombreCompleto}' \\";
                proc_Str += $"--MEDICOENCARGADO '{doc.NombreCompleto}' \\";
                proc_Str += $"--MES '{tiempoMes}' \\";
                psi.Arguments = proc_Str;

				psi.UseShellExecute = false;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;

				Process proc = new Process
				{
					StartInfo = psi
				};

				proc.Start();
				proc.WaitForExit();

				string createdFileName = $"./const_{infoCons.pacienteID}.pdf";
				if (!System.IO.File.Exists(createdFileName))
				{
					return NotFound();
				}
				Response.Headers.ContentDisposition.Append("inline; filename=" + createdFileName);
				var bytes = await System.IO.File.ReadAllBytesAsync(createdFileName);
				System.IO.File.Delete(createdFileName);
				return File(bytes, "application/pdf", $"constancia_{infoCons.pacienteID}.pdf");
			}
			catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost ("vasectomia")]
        public async Task<ActionResult> generarVasectomia([FromBody] InfoHistorialVasectomia infoVas)
        {
            try
			{
				Paciente info = service.getClassPaciente(infoVas.pacienteID);

				if (info == null)
				{
					Console.WriteLine("No encuentro el paciente con el ID " + infoVas.pacienteID);
					return NotFound();
				}

                // ANTES DE TODO:
                // Hay que encontrar si el paciente tiene un historial medico.
                // Ya que este contendrá la información sobre sus opiniones del motivo de solicitud.
                Historiaclinica historiaMedica = serviceHistoria.getHistoriaClassByNumExp(infoVas.pacienteID);
                Motivosolicitud motivo = serviceHistoria.getClassMotivo(historiaMedica.IdHistoriaClinica);

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = $"/bin/sh";
				psi.WorkingDirectory = "./";
                // Crea el comando para correr la aplicación.
                string numeroExpediente = infoVas.pacienteID;
                string proc_Str = $"-c \"./vasectomia_exp.sh --NUMEXPEDIENTE {numeroExpediente} \\";
				//proc_Str += $"--NUMEXPEDIENTE {numeroExpediente} \\";
				// TODO: ¡Obtener unidad médica!
				proc_Str += $"--UNIDAD_MEDICA '{historiaMedica.FkHospitalNavigation.UMedica}' \\";
				// TODO: ¡Obtener Dirección!
				proc_Str += $"--UNIDAD_DIRECCION '{historiaMedica.FkHospitalNavigation.EntidadFederativa}' \\";
                // TODO: ¡Obtener numero telefónico!
                proc_Str += "--UNIDAD_TELEFONO '3719501438' \\";
                proc_Str += $"--NOMPACIENTE '{info.NombreCompleto}' \\";
                proc_Str += $"--EDAD {info.Edad()} \\";
				proc_Str += $"--FECHA_NACIMIENTO '{info.FechaNac.ToString("dd 'de' MMMM 'del' yyyy")}' \\";
				proc_Str += $"--ESTADO_CIVIL '{info.FkEstadoCivilNavigation.NombreEstado}' \\";
                proc_Str += $"--ESCOLARIDAD '{info.FkEscolaridadNavigation.NombreEscolaridad}' \\";
                proc_Str += $"--OCUPACION '{info.FkOcupacionNavigation.NombreOcupacion}' \\";
                proc_Str += $"--IVS '{info.Ivs}' \\";
                proc_Str += $"--RELIGION '{info.FkReligionNavigation.NombreReligion}' \\";
                proc_Str += $"--REFERENCIA '{info.FkLugarReferenciaNavigation.NombreLugar}' \\";
                proc_Str += $"--NUM_HIJOS {info.NumHijosVivos} \\";
                proc_Str += $"--EDAD_MENOR {info.EdadHijoMenor} \\";
                proc_Str += $"--NOMBRE_ESPOSA '{info.NombreEsposa}' \\";
                proc_Str += $"--DUR_RELACION {info.AosRelac} \\";
                proc_Str += $"--DOMICILIO_ACTUAL '{info.CalleCasa}' \\";
                proc_Str += $"--DOMICILIO_TELEFONO {info.TelCasa} \\";
                proc_Str += $"--TRABAJO_ACTUAL {info.ColTrabajo} \\";
                proc_Str += $"--TRABAJO_TELEFONO {info.TelTrabajo} \\";
                // TODO: Esto deberia ser un index, pero fue registrado como strings en la base de datos...
                proc_Str += $"--MOTIVO_CAUSA_INT_HIJOS {infoVas.causaHijos} \\";
                proc_Str += $"--MOTIVO_CAUSA_OPN_PAREJA {motivo.FkOpinion} \\";
                proc_Str += $"--MOTIVO_CAUSA_PLA_FAMILIAR {motivo.FkMetodoPlanificacion} \\";

                // Pagina 2

                proc_Str += $"--ANTECEDENTES_HEREDOF {historiaMedica.Historiaexploracion.AntFamiliares} \\";
                proc_Str += $"--ANTECEDENTES_NOPAT {historiaMedica.Historiaexploracion.AntPersonalesNoPat} \\";
                proc_Str += $"--ANTECEDENTES_PAT {historiaMedica.Historiaexploracion.AntPersonalesPat} \\";

                proc_Str += $"--TA '{historiaMedica.Historiaexploracion.Ta}' \\";
                proc_Str += $"--PESO '{historiaMedica.Historiaexploracion.Peso}' \\";
                proc_Str += $"--TALLA '{historiaMedica.Historiaexploracion.Talla}' \\";
                proc_Str += $"--FC '{historiaMedica.Historiaexploracion.Fc}' \\";
                proc_Str += $"--FR '{historiaMedica.Historiaexploracion.Fr}' \\";
                proc_Str += $"--TEM '{historiaMedica.Historiaexploracion.Tem}' \\";

                proc_Str += $"--EXPLORACION_ORGANOS {historiaMedica.Historiaexploracion.ExpOrganos} \\";
                proc_Str += $"--TIPO_PACIENTE {historiaMedica.Historiaexploracion.TipoPaciente} \\";

                proc_Str += $"--FECHA_CIRUGIA '{historiaMedica.Procquirurgico.FechaCirugia.ToString("dd 'de' MMMM 'del' yyyy")}' \\";
                proc_Str += $"--NOM_CIRUJANO '{historiaMedica.Procquirurgico.FkDoctorNavigation.NombreCompleto}' \\";
                proc_Str += $"--NOTA_QUIR '{historiaMedica.Procquirurgico.NotaQuirurgica}' \\";
                proc_Str += $"--PAT_ENCONTRADA '{historiaMedica.Procquirurgico.Patologia}'";

				psi.Arguments = proc_Str;
				psi.UseShellExecute = false;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;

				Process proc = new Process
				{
					StartInfo = psi
				};

				proc.Start();
				string output = proc.StandardOutput.ReadToEnd();
				Console.WriteLine(output);
				proc.WaitForExit();

				string createdFileName = $"./vasec_{numeroExpediente}.pdf";
				if (!System.IO.File.Exists(createdFileName))
				{
                    Console.WriteLine("Could not find the file to output.");
					return NotFound();
				}
				Response.Headers.ContentDisposition.Append("inline; filename=" + createdFileName);
				var bytes = await System.IO.File.ReadAllBytesAsync(createdFileName);
				System.IO.File.Delete(createdFileName);
				return File(bytes, "application/pdf", $"vasectomia_{numeroExpediente}.pdf");
			}
			catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost ("instrucciones")]
        public async Task<ActionResult> generarInstrucciones([FromBody] InfoPostOper infoVas)
        {
            try
			{
				Paciente info = service.getClassPaciente(infoVas.pacienteID);

				if (info == null)
				{
					Console.WriteLine("No encuentro el paciente con el ID " + infoVas.pacienteID);
					return NotFound();
				}

                // ANTES DE TODO:
                // Hay que encontrar si el paciente tiene un historial medico.
                // Ya que este contendrá la información sobre sus opiniones del motivo de solicitud.
                Historiaclinica historiaMedica = serviceHistoria.getHistoriaClassByNumExp(infoVas.pacienteID);
                Motivosolicitud motivo = serviceHistoria.getClassMotivo(historiaMedica.IdHistoriaClinica);

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = $"/bin/sh";
				psi.WorkingDirectory = "./";
                // Crea el comando para correr la aplicación.
                string numeroExpediente = infoVas.pacienteID;
                string proc_Str = $"-c \"./post-inst.sh --NOMMEDICO '{infoVas.medicoResponsable}' \\";
                proc_Str += $"--NUMEXPEDIENTE {numeroExpediente} \\";
				proc_Str += $"--UNIDAD_MEDICA '{infoVas.unidadMedica}' \\";
				proc_Str += $"--UNIDAD_DIRECCION '{historiaMedica.FkHospitalNavigation.EntidadFederativa}' \\";
                proc_Str += $"--NOMPACIENTE '{info.NombreCompleto}'";

				psi.Arguments = proc_Str;
				psi.UseShellExecute = false;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;

				Process proc = new Process
				{
					StartInfo = psi
				};

				proc.Start();
				string output = proc.StandardOutput.ReadToEnd();
				Console.WriteLine(output);
				proc.WaitForExit();

				string createdFileName = $"./post-{numeroExpediente}.pdf";
				if (!System.IO.File.Exists(createdFileName))
				{
                    Console.WriteLine("Could not find the file to output.");
					return NotFound();
				}
				Response.Headers.ContentDisposition.Append("inline; filename=" + createdFileName);
				var bytes = await System.IO.File.ReadAllBytesAsync(createdFileName);
				System.IO.File.Delete(createdFileName);
				return File(bytes, "application/pdf", $"instrucciones_{numeroExpediente}.pdf");
			}
			catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet ("generarNotaMedica/{numExp}")]
        public async Task<ActionResult> generarNotaMedica(string numExp)
        {
            try
			{
				Paciente info = service.getClassPaciente(numExp);

				if (info == null)
				{
					Console.WriteLine("No encuentro el paciente con el ID " + numExp);
					return NotFound();
				}

                // ANTES DE TODO:
                // Hay que encontrar si el paciente tiene un historial medico.
                // Ya que este contendrá la información sobre sus opiniones del motivo de solicitud.
                Console.WriteLine("Historia");
                Historiaclinica historiaMedica = serviceHistoria.getHistoriaClassByNumExp(numExp);
                Console.WriteLine("Motivo");
                Motivosolicitud motivo = serviceHistoria.getClassMotivo(historiaMedica.IdHistoriaClinica);
                Console.WriteLine("nota");
                Notamedica nota = serviceNotaMedica.geClassNotaMedicaByNumExp(numExp);
                Console.WriteLine("Ficha");
                Fichaidentificacion ficha = serviceFicha.getClassFichaByNumExp(numExp);

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = $"/bin/sh";
				psi.WorkingDirectory = "./";
                DateTime ahora = DateTime.Now;
                // Crea el comando para correr la aplicación.
                string numeroExpediente = numExp;
                string proc_Str = $"-c \"./nota_medica.sh --NOMPACIENTE '{info.NombreCompleto}' \\";
                proc_Str += $"--NUMEXPEDIENTE {numeroExpediente} \\";
                proc_Str += $"--DIA {ahora.Day} \\";
                proc_Str += $"--MES {ahora.ToString("MMMM")} \\";
                proc_Str += $"--YEAR {ahora.Year} \\";
                proc_Str += $"--EDAD {info.Edad()} \\";
                proc_Str += $"--SERVICIO 'servicio' \\";
                proc_Str += $"--DIAGNOSTICO_PRE '{nota.DiagnosticoPre}' \\";
                proc_Str += $"--DIAGNOSTICO_POS '{nota.DiagnosticoPost}' \\";
                proc_Str += $"--CIRUJANO '{nota.FkDoctorNavigation.NombreCompleto}' \\";
                proc_Str += $"--COMPLICACION '{nota.Complicaciones}' \\";
                proc_Str += $"--DESCRIPCION '{nota.Descripcion}' \\";
                proc_Str += $"--PRRP '{nota.Preparacion}' \\";
                proc_Str += $"--TIPO_ANES '{nota.TipoAnestesia}' \\";
                proc_Str += $"--FECHA_CIR '{nota.FechaCirugia.ToString("dd 'de' MMMM 'del' yyyy")}' \\";
                proc_Str += $"--GENERO 'Mas' \\";
                proc_Str += $"--NUMSEGURO '12342134' \\";
                proc_Str += $"--SERVICIO 'servicio' \\";
                proc_Str += $"--DIAGNOSTICO '{ficha.Diagnostico}' \\";

				psi.Arguments = proc_Str;
				psi.UseShellExecute = false;
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardError = true;

				Process proc = new Process
				{
					StartInfo = psi
				};

				proc.Start();
				string output = proc.StandardOutput.ReadToEnd();
				Console.WriteLine(output);
				proc.WaitForExit();

				string createdFileName = $"./nota-{numeroExpediente}.pdf";
				if (!System.IO.File.Exists(createdFileName))
				{
                    Console.WriteLine("Could not find the file to output.");
					return NotFound();
				}
				Response.Headers.ContentDisposition.Append("inline; filename=" + createdFileName);
				var bytes = await System.IO.File.ReadAllBytesAsync(createdFileName);
				System.IO.File.Delete(createdFileName);
				return File(bytes, "application/pdf", $"NotaMedica_{numeroExpediente}.pdf");
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

    public class InfoPostOper
    {
        public string pacienteID { get; set; }
        public string medicoResponsable { get; set; }
        public string unidadMedica { get; set; }
    }

    public class InfoHistorialVasectomia
    {
		public string pacienteID { get; set; }
        public int causaHijos { get; set; }
		public int opinionPareja { get; set; }
		public int planificacionFamiliar { get; set; }
	}

    public class InfoConsentimiento
    {
        public string pacienteID { get; set; }
        public string fam1 { get; set; }
        public string fam2 { get; set; }
        public int personal { get; set; }
        public int doc { get; set; }
    }
}
