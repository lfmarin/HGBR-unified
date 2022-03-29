using System.Linq;
using API_Hospital_Boca.Models;

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

                if (!aux.Nombre.Equals(pa.Nombre)) aux.Nombre = pa.Nombre;
                if (!aux.ApPaterno.Equals(pa.ApPaterno)) aux.ApPaterno = pa.ApPaterno;
                if (!aux.ApMaterno.Equals(pa.ApMaterno)) aux.ApMaterno = pa.ApMaterno;
                if (!aux.FechaNac.Equals(pa.FechaNac)) aux.FechaNac = pa.FechaNac;
                if (aux.FkEstadoCivil != pa.FkEstadoCivil) aux.FkEstadoCivil = pa.FkEstadoCivil;
                if (aux.Ivs != pa.Ivs) aux.Ivs = pa.Ivs;
                if (aux.FkEscolaridad != pa.FkEscolaridad) aux.FkEscolaridad = pa.FkEscolaridad;
                if (aux.FkOcupacion != pa.FkOcupacion) aux.FkOcupacion = pa.FkOcupacion;
                if (aux.FkReligion != pa.FkReligion) aux.FkReligion = pa.FkReligion;
                if (aux.FkLugarReferencia != pa.FkLugarReferencia) aux.FkLugarReferencia = pa.FkLugarReferencia;
                if (aux.NumHijosVivos != pa.NumHijosVivos) aux.NumHijosVivos = pa.NumHijosVivos;
                if (aux.EdadHijoMenor != pa.EdadHijoMenor) aux.EdadHijoMenor = pa.EdadHijoMenor;
                if (!aux.NombreEsposa.Equals(pa.NombreEsposa)) aux.NombreEsposa = pa.NombreEsposa;
                if (aux.AosRelac != pa.AosRelac) aux.AosRelac = pa.AosRelac;
                if (!aux.CalleCasa.Equals(pa.CalleCasa)) aux.CalleCasa = pa.CalleCasa;
                if (aux.NumCasa != pa.NumCasa) aux.NumCasa = pa.NumCasa;
                if (!aux.ColCasa.Equals(pa.ColCasa)) aux.ColCasa = pa.ColCasa;
                if (!aux.TelCasa.Equals(pa.TelCasa)) aux.TelCasa = pa.TelCasa;
                if (!aux.CalleTrabajo.Equals(pa.CalleTrabajo)) aux.CalleTrabajo = pa.CalleTrabajo;
                if (aux.NumTrabajo != pa.NumTrabajo) aux.NumTrabajo = pa.NumTrabajo;
                if (!aux.ColTrabajo.Equals(pa.ColTrabajo)) aux.ColTrabajo = pa.ColTrabajo;
                if (!aux.TelTrabajo.Equals(pa.TelTrabajo)) aux.TelTrabajo = pa.TelTrabajo;
                
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
