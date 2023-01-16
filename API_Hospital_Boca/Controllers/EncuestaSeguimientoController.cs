using Microsoft.AspNetCore.Mvc;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Diagnostics;
using System;

namespace API_Hospital_Boca.Controllers
{
    [Route("hospitalBoca/EncuestaSeguimiento")]
    public class EncuestaSeguimientoController : ControllerBase
    {
        private readonly IServiceEncuestaSeguimeinto service;

        public EncuestaSeguimientoController( IServiceEncuestaSeguimeinto service)
        {
            this.service = service;
        }

        [HttpGet ("{numExp}")]
        public IActionResult getEncuestaByNumExp(string numExp)
        {
            try
            {
                var res = service.getEncuestaSeguimientoByNumExp(numExp);
                return Ok(res);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet ("generar/{numExp}")]
        public async Task<ActionResult> generarEncuestaSeg(string numExp)
        {
            try
            {
                Encuestaseguimiento src = service.getEncuestaClassSeguimientoByNumExp(numExp);

				if (src == null)
				{
					Console.WriteLine("No encuentro el paciente con el ID " + numExp);
					return NotFound();
				}

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = $"/bin/sh";
				psi.WorkingDirectory = "./";
				psi.Arguments = "-c \"pwd\"";
                // Crea el comando para correr la aplicación.
                string proc_Str = $"-c \"./encuesta.sh --CENTRO_SALUD 'Hospital Yes' \\";
				// proc_Str += $"--CENTRO_SALUD 'Hospital Yes' \\";
                proc_Str += $"--NUMEXPEDIENTE '{numExp}' \\";
                proc_Str += $"--NOMBRE '{src.FkPacienteNavigation.NombreCompleto}' \\";
                proc_Str += $"--EDAD {src.FkPacienteNavigation.Edad()} \\";
                proc_Str += $"--ESCOLARIDAD '{src.FkPacienteNavigation.FkEscolaridadNavigation.NombreEscolaridad}' \\";
                proc_Str += $"--OCUPACION '{src.FkPacienteNavigation.FkOcupacionNavigation.NombreOcupacion}' \\";
                proc_Str += $"--NUM_HIJOS {src.FkPacienteNavigation.NumHijosVivos} \\";
                proc_Str += $"--EDAD_MENOR {src.FkPacienteNavigation.EdadHijoMenor} \\";
                proc_Str += $"--RELIGION '{src.FkPacienteNavigation.FkReligionNavigation.NombreReligion}' \\";
                proc_Str += $"--FECHA_VASECTOMIA '{src.FechaVasectomia.ToString()}' \\";
                proc_Str += $"--INFO_VASECTOMIA '{src.OrigenInfo}' \\";
                proc_Str += $"--ORIENT_VASECTOMIA '' \\";
                proc_Str += $"--CENTRO_REFERIDO {(src.Referido ? 1 : 0)} \\";
                proc_Str += $"--CENTRO_DEF '{src.FkHospitalReferenciaNavigation.UMedica}' \\";
                proc_Str += $"--TRATO_PERSONAL {src.FkCalidad} \\";
                proc_Str += $"--SATISFECHO {(src.Satisfaccion ? 1 : 0)} \\";
                proc_Str += $"--RAZON_SATISF '{src.MotivoSatisfaccion}' \\";
                proc_Str += $"--COMPLICACION_CIR {(src.Complicacion ? 1 : 0)} \\";
                proc_Str += $"--COMPLICACION_DESC '{src.MotivoComplicacion}' \\";
                proc_Str += $"--RELACION_SEX {src.FkCalidadRelacion} \\";
                proc_Str += $"--RELACION_PEOR {src.MotivoCalidad} \\";
                proc_Str += $"--FECHA_NEGATIVIDAD '{src.FechaNegativo}' \\";
                proc_Str += $"--ESPERMA_LUGAR '{src.LugarEspermaconteo}' \\";
                proc_Str += $"--RECOMENDAR_VASEC {(src.Recomendacion ? 1 : 0)} \\";
                proc_Str += $"--RAZON_VASEC '{src.MotivoRecomendacion}' \\";
                proc_Str += $"--LUGARREC_VASEC {(src.LugarVasectomia ? 1 : 0)} \\";
                proc_Str += $"--RAZON_LUGARREC '{src.MotivoLugar}' \\";
                proc_Str += $"--MEJORAR_SERV {(src.RecomendacionHospital ? 1 : 0)} \\";
                proc_Str += $"--MEJORAR_RAZON '{src.CualRecomendacion}'";

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
				proc.WaitForExit();

				string createdFileName = $"./encue_{numExp}.pdf";
				if (!System.IO.File.Exists(createdFileName))
				{
                    Console.WriteLine("Could not find the file to output.");
					return NotFound();
				}
				Response.Headers.ContentDisposition.Append("inline; filename=" + createdFileName);
				var bytes = await System.IO.File.ReadAllBytesAsync(createdFileName);
				System.IO.File.Delete(createdFileName);
				return File(bytes, "application/pdf", $"encue_{numExp}.pdf");
            } catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [HttpPost ("update")]
        public IActionResult updateEncuestaSeg([FromBody] Encuestaseguimiento es)
        {
            try
            {
                service.updateEncuestaSeguimiento(es);
                return Ok(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}