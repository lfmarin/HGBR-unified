using System.Linq;
using API_Hospital_Boca.Models;
using System;

namespace API_Hospital_Boca.Bussiness
{
    public class ServicePacientes: API_Hospital_Boca.Services.IServicePacientes
    {
        private readonly hospital_bocaContext context;
        public ServicePacientes(hospital_bocaContext context)
        {
            this.context = context;
        }

        public void deletPaciente(string numExpediente)
        {
            try
            {
                Paciente pa = context.Pacientes.Where(p => p.NoExpediente.Equals(numExpediente)).First();
                context.Pacientes.Remove(pa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAll()
        {
            try
            {
                return context.Pacientes.Select(p => new {
                    NoExpediente = p.NoExpediente,
                    Nombre = p.Nombre,
                    ApPaterno = p.ApPaterno,
                    ApMaerno = p.ApMaterno,
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
        public Paciente getClassPaciente(string numExpediente)
        {
            try
            {
                Console.WriteLine("Attempting to fetch the patient");
                Paciente pa = context.Pacientes.Where(p => p.NoExpediente.Equals(numExpediente)).First();

                // Ok, con el paciente obtenido, llenemos la información extra.
                Escolaridad sco = context.Escolaridads.Where(p => p.IdEscolaridad.Equals(pa.FkEscolaridad)).First();
                pa.FkEscolaridadNavigation = sco;

                Estadocivil EC = context.Estadocivils.Where(p => p.IdEstadoCivil.Equals(pa.FkEstadoCivil)).First();
                pa.FkEstadoCivilNavigation = EC;

                Ocupacion Opc = context.Ocupacions.Where(p => p.IdOcupacion.Equals(pa.FkOcupacion)).First();
                pa.FkOcupacionNavigation = Opc;

                Lugarreferencium Ref = context.Lugarreferencia.Where(p => p.IdLugar.Equals(pa.FkLugarReferencia)).FirstOrDefault();
                pa.FkLugarReferenciaNavigation = Ref;

                Religion Reg = context.Religions.Where(p => p.IdReligion.Equals(pa.FkReligion)).First();
                pa.FkReligionNavigation = Reg;

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
                return context.Pacientes.Where(p => p.NoExpediente == numExpediente).Select(pa => new {
                    NoExpediente = pa.NoExpediente,
                    Nombre = pa.Nombre,
                    ApPaterno = pa.ApPaterno,
                    ApMaterno = pa.ApMaterno,
                    FechaNac = pa.FechaNac,
                    FkEstadoCivil = pa.FkEstadoCivil,
                    Ivs = pa.Ivs,
                    FkEscolaridad = pa.FkEscolaridad,
                    FkOcupacion = pa.FkOcupacion,
                    FkReligion = pa.FkReligion,
                    FkLugarReferencia = pa.FkLugarReferencia,
                    NumHijosVivos = pa.NumHijosVivos,
                    EdadHijoMenor = pa.EdadHijoMenor,
                    NombreEsposa = pa.NombreEsposa,
                    AosRelac = pa.AosRelac,
                    CalleCasa = pa.CalleCasa,
                    NumCasa = pa.NumCasa,
                    ColCasa = pa.ColCasa,
                    TelCasa = pa.TelCasa,
                    CalleTrabajo = pa.CalleTrabajo,
                    NumTrabajo = pa.NumTrabajo,
                    ColTrabajo = pa.ColTrabajo,
                    TelTrabajo = pa.TelTrabajo
                }).First();
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public void savePaciente(Paciente pa)
        {
            try
            {
                context.Pacientes.Add(pa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updatePaciente(Paciente pa)
        {
            try
            {
                Paciente aux = context.Pacientes.Where(p => p.NoExpediente == pa.NoExpediente).First();

                if (aux.Nombre == null) aux.Nombre = pa.Nombre;
                else if (!aux.Nombre.Equals(pa.Nombre)) aux.Nombre = pa.Nombre;
                if (aux.ApPaterno == null) aux.ApPaterno = pa.ApPaterno;
                else if (!aux.ApPaterno.Equals(pa.ApPaterno)) aux.ApPaterno = pa.ApPaterno;
                if (aux.ApMaterno == null) aux.ApMaterno = pa.ApMaterno;
                else if (!aux.ApMaterno.Equals(pa.ApMaterno)) aux.ApMaterno = pa.ApMaterno;
                if (aux.FechaNac == null) aux.FechaNac = pa.FechaNac;
                else if (!aux.FechaNac.Equals(pa.FechaNac)) aux.FechaNac = pa.FechaNac;
                if (aux.FkEstadoCivil == null) aux.FkEstadoCivil = pa.FkEstadoCivil;
                else if (aux.FkEstadoCivil != pa.FkEstadoCivil) aux.FkEstadoCivil = pa.FkEstadoCivil;
                if (aux.Ivs == null) aux.Ivs = pa.Ivs;
                else if (aux.Ivs != pa.Ivs) aux.Ivs = pa.Ivs;
                if (aux.FkEscolaridad == null) aux.FkEscolaridad = pa.FkEscolaridad;
                else if (aux.FkEscolaridad != pa.FkEscolaridad) aux.FkEscolaridad = pa.FkEscolaridad;
                if (aux.FkOcupacion == null) aux.FkOcupacion = pa.FkOcupacion;
                else if (aux.FkOcupacion != pa.FkOcupacion) aux.FkOcupacion = pa.FkOcupacion;
                if (aux.FkReligion == null) aux.FkReligion = pa.FkReligion;
                else if (aux.FkReligion != pa.FkReligion) aux.FkReligion = pa.FkReligion;
                if (aux.FkLugarReferencia == null) aux.FkLugarReferencia = pa.FkLugarReferencia;
                else if (aux.FkLugarReferencia != pa.FkLugarReferencia) aux.FkLugarReferencia = pa.FkLugarReferencia;
                if (aux.NumHijosVivos == null) aux.NumHijosVivos = pa.NumHijosVivos;
                else if (aux.NumHijosVivos != pa.NumHijosVivos) aux.NumHijosVivos = pa.NumHijosVivos;
                if (aux.EdadHijoMenor == null) aux.EdadHijoMenor = pa.EdadHijoMenor;
                else if (aux.EdadHijoMenor != pa.EdadHijoMenor) aux.EdadHijoMenor = pa.EdadHijoMenor;
                if (aux.NombreEsposa == null) aux.NombreEsposa = pa.NombreEsposa;
                else if (!aux.NombreEsposa.Equals(pa.NombreEsposa)) aux.NombreEsposa = pa.NombreEsposa;
                if (aux.AosRelac == null) aux.AosRelac = pa.AosRelac;
                else if (aux.AosRelac != pa.AosRelac) aux.AosRelac = pa.AosRelac;
                if (aux.CalleCasa == null) aux.CalleCasa = pa.CalleCasa;
                else if (!aux.CalleCasa.Equals(pa.CalleCasa)) aux.CalleCasa = pa.CalleCasa;
                if (aux.NumCasa == null) aux.NumCasa = pa.NumCasa;
                else if (aux.NumCasa != pa.NumCasa) aux.NumCasa = pa.NumCasa;
                if (aux.ColCasa == null) aux.ColCasa = pa.ColCasa;
                else if (!aux.ColCasa.Equals(pa.ColCasa)) aux.ColCasa = pa.ColCasa;
                if (aux.TelCasa == null) aux.TelCasa = pa.TelCasa;
                else if (!aux.TelCasa.Equals(pa.TelCasa)) aux.TelCasa = pa.TelCasa;
                if (aux.CalleTrabajo == null) aux.CalleTrabajo = pa.CalleTrabajo;
                else if (!aux.CalleTrabajo.Equals(pa.CalleTrabajo)) aux.CalleTrabajo = pa.CalleTrabajo;
                if (aux.NumTrabajo == null) aux.NumTrabajo = pa.NumTrabajo;
                else if (aux.NumTrabajo != pa.NumTrabajo) aux.NumTrabajo = pa.NumTrabajo;
                if (aux.ColTrabajo == null) aux.ColTrabajo = pa.ColTrabajo;
                else if (!aux.ColTrabajo.Equals(pa.ColTrabajo)) aux.ColTrabajo = pa.ColTrabajo;
                if (aux.TelTrabajo == null) aux.TelTrabajo = pa.TelTrabajo;
                else if (!aux.TelTrabajo.Equals(pa.TelTrabajo)) aux.TelTrabajo = pa.TelTrabajo;
                
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
