using System.Linq;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using System;

namespace API_Hospital_Boca.Bussiness
{
    public class PacienteServices : IPacienteServices
    {
        private readonly HospitalBocaContext context;
        public PacienteServices(HospitalBocaContext context)
        {
            this.context = context;
        }


        public IQueryable<object> getAll()
        {
            try
            {
                return context.Pacientesarches.Select(p => new {
                    Folio = p.NoExpediente,
                    Nombre = p.Nombre,
                    ApPaterno = p.ApPaterno,
                    ApMaterno = p.ApMaterno,
                    FechaNacimiento = p.FechaNac
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /* TODO: Esta acción resulta ser incompatible con Linq.dll,
         * Dado la dirección en donde está obteniendo la información por medio
         * del IQuerable<>. hay que verificar la acción si hay una opción donde
         * no es valido o nulo, aun que el valor de Paciente por alguna razón
         * no me deja colocarlo en nulo, aun que puede ocurrir casos donde
         * puede ser nulo, justo como este.
        */
        public Pacientesarch getClassPaciente(string numExpediente)
        {
            try
            {
                Console.WriteLine("Attempting to fetch the patient");
                Pacientesarch pa = context.Pacientesarches.Where(p => p.NoExpediente.Equals(numExpediente)).First();

                // Ok, con el paciente obtenido, llenemos la información extra.
                Estadocivil estado = context.Estadocivils.Where(p => p.IdEstadoCivil.Equals(pa.FkEstadoCivil)).First();
                pa.FkEstadoCivilNavigation = estado;

                Tipoasentamiento asent = context.Tipoasentamientos.Where(p => p.Id.Equals(pa.FkTipoColCasa)).First();
                pa.FkTipoColCasaNavigation = asent;

                Tipovialidad vial = context.Tipovialidads.Where(p => p.Id.Equals(pa.FkTipoCalleCasa)).FirstOrDefault();
                pa.FkTipoCalleCasaNavigation = vial;

                Sexo sexo = context.Sexos.Where(p => p.Id.Equals(pa.FkSexo)).First();
                pa.FkSexoNavigation = sexo;

                return pa;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public object getPaciente(string numExpediente)
        {
            try
            {
                return context.Pacientesarches.Where(p => p.NoExpediente.Equals(numExpediente)).Select(pa => new {
                    Folio = pa.NoExpediente,
                    Nombre = pa.Nombre,
                    ApPaterno = pa.ApPaterno,
                    ApMaterno = pa.ApMaterno,
                    Curp = pa.Curp,
                    FechaNac = pa.FechaNac,
                    HoraNac = pa.HoraNac,
                    EntidadNac = pa.EntidadNac,
                    // Edad = pa.Edad,
                    EdadYears = pa.EdadYears,
                    EdadMounths = pa.EdadMonths,
                    EdadDays = pa.EdadDays,
                    EdadHours = pa.EdadHours,
                    NacidoHosp = pa.NacidoHospital,
                    FKSexo = pa.FkSexo,
                    Peso = pa.Peso,
                    Talla = pa.Talla,
                    FKEstadoConyugal = pa.FkEstadoCivil,
                    Insabi = pa.Insabi,
                    Gratuitidad = pa.Gratuitidad,
                    Indigena = pa.Indigena,
                    LenguaIndigena = pa.LenguaIndigena,
                    CualLengua = pa.CualLengua,
                    FKTipoVialidad = pa.FkTipoCalleCasa,
                    NombreVialidad = pa.CalleCasa,
                    NumExt = pa.NumCasa,
                    NumInt = pa.NumCasaInt,
                    FKTipoAsentamiento = pa.FkTipoColCasa,
                    NombreAsentamiento = pa.ColCasa,
                    Cp = pa.Cp,
                    Localidad = pa.Localidad,
                    MunicipioDeleg = pa.Municipio,
                    Entidad = pa.EntidadFederativa,
                    Pais = pa.Pais,
                    Telefono = pa.TelCasa
                }).First();
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public void savePaciente(Pacientesarch paciente)
        {
            try
            {
                context.Pacientesarches.Add(paciente);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updatePaciente(Pacientesarch paciente)
        {
            try
            {
                Pacientesarch aux = context.Pacientesarches.Where(p => p.NoExpediente == paciente.NoExpediente).First();

                if (!aux.Nombre.Equals(paciente.Nombre)) aux.Nombre = paciente.Nombre;
                if (!aux.ApPaterno.Equals(paciente.ApPaterno)) aux.ApPaterno = paciente.ApPaterno;
                if (!aux.ApMaterno.Equals(paciente.ApMaterno)) aux.ApMaterno = paciente.ApMaterno;
                if (!aux.Curp.Equals(paciente.Curp)) aux.Curp = paciente.Curp;
                if (!aux.FechaNac.Equals(paciente.FechaNac)) aux.FechaNac = paciente.FechaNac;
                if (!aux.HoraNac.Equals(paciente.HoraNac)) aux.HoraNac = paciente.HoraNac;
                if (!aux.EntidadNac.Equals(paciente.EntidadNac)) aux.EntidadNac = paciente.EntidadNac;
                // if (aux.Edad != paciente.Edad) aux.Edad = paciente.Edad;
                if (aux.EdadYears != paciente.EdadYears) aux.EdadYears = paciente.EdadYears;
                if (aux.EdadMonths != paciente.EdadMonths) aux.EdadMonths = paciente.EdadMonths;
                if (aux.EdadDays != paciente.EdadDays) aux.EdadDays = paciente.EdadDays;
                if (aux.EdadHours != paciente.EdadHours) aux.EdadHours = paciente.EdadHours;
                if (aux.NacidoHospital != paciente.NacidoHospital) aux.NacidoHospital = paciente.NacidoHospital;
                if (aux.FkSexo != paciente.FkSexo) aux.FkSexo = paciente.FkSexo;
                if (aux.Peso != paciente.Peso) aux.Peso = paciente.Peso;
                if (aux.Talla != paciente.Talla) aux.Talla = paciente.Talla;
                if (aux.FkEstadoCivil != paciente.FkEstadoCivil) aux.FkEstadoCivil = paciente.FkEstadoCivil;
                if (aux.Insabi != paciente.Insabi) aux.Insabi = paciente.Insabi;
                if (aux.Gratuitidad != paciente.Gratuitidad) aux.Gratuitidad = paciente.Gratuitidad;
                if (aux.Indigena != paciente.Indigena) aux.Indigena = paciente.Indigena;
                if (aux.LenguaIndigena != paciente.LenguaIndigena) aux.LenguaIndigena = paciente.LenguaIndigena;
                if (!aux.CualLengua.Equals(paciente.CualLengua)) aux.CualLengua = paciente.CualLengua;
                if (aux.FkTipoCalleCasa != paciente.FkTipoCalleCasa) aux.FkTipoCalleCasa = paciente.FkTipoCalleCasa;
                if (!aux.CalleCasa.Equals(paciente.CalleCasa)) aux.CalleCasa = paciente.CalleCasa;
                if (!aux.NumCasa.Equals(paciente.NumCasa)) aux.NumCasa = paciente.NumCasa;
                if (!aux.NumCasaInt.Equals(paciente.NumCasaInt)) aux.NumCasaInt = paciente.NumCasaInt;
                if (aux.FkTipoColCasa != paciente.FkTipoColCasa) aux.FkTipoColCasa = paciente.FkTipoColCasa;
                if (!aux.ColCasa.Equals(paciente.ColCasa)) aux.ColCasa = paciente.ColCasa;
                if (aux.Cp != paciente.Cp) aux.Cp = paciente.Cp;
                if (!aux.Localidad.Equals(paciente.Localidad)) aux.Localidad = paciente.Localidad;
                if (!aux.Municipio.Equals(paciente.Municipio)) aux.Municipio = paciente.Municipio;
                if (!aux.EntidadFederativa.Equals(paciente.EntidadFederativa)) aux.EntidadFederativa = paciente.EntidadFederativa;
                if (!aux.Pais.Equals(paciente.Pais)) aux.Pais = paciente.Pais;
                if (!aux.TelCasa.Equals(paciente.TelCasa)) aux.TelCasa = paciente.TelCasa;

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public void deletePaciente(string numExpediente)
        {
            try
            {
                Pacientesarch pa = context.Pacientesarches.Where(p => p.NoExpediente.Equals(numExpediente)).First();
                context.Pacientesarches.Remove(pa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}


