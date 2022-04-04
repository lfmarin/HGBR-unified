using API_Hospital_Boca.Models;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Utilities;
using System.Linq;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceFichaIdentificacion : IServiceFichaIdentificacion
    {
        private readonly hospital_bocaContext context;
        public ServiceFichaIdentificacion(hospital_bocaContext context)
        {
            this.context = context;
        }

        public void saveFichaIdentificacion(Fichaidentificacion fi)
        {
            try
            {
                context.Fichaidentificacions.Add(fi);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateFichaIdentificacion(Fichaidentificacion fi)
        {
            try
            {
                var res = context.Fichaidentificacions.Where(f => f.FkPaciente == fi.FkPaciente).First();

                if (!Utils.isTheSame(res.Servicio, fi.Servicio)) res.Servicio = fi.Servicio;
                if (!Utils.isTheSame(res.Diagnostico, fi.Diagnostico)) res.Diagnostico = fi.Diagnostico;

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public void saveNotaMedica(Notamedica nm)
        {
            try
            {
                context.Notamedicas.Add(nm);  

                context.SaveChanges(); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllNotasMedicas(int numFicha)
        {
            try
            {
                return context.Notamedicas.Where(no => no.FkFicha == numFicha).Select(n => new {
                    FechaHora = n.FechaHora,
                    SignosVitales = n.SignosVitales,
                    DiagnosticoPre = n.DiagnosticoPre,
                    CirugiaProgamada = n.CirugiaProgramada,
                    FechaCirugia = n.FechaCirugia,
                    TipoAnestesia = n.TipoAnestesia,
                    Preparacion = n.Preparacion,
                    FkDoctor = n.FkDoctor,
                    DiagnosticoPost = n.DiagnosticoPost,
                    Complicaciones = n.Complicaciones,
                    Descripcion = n.Descripcion
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}