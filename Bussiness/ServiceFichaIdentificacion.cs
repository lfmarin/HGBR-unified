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

        public void saveCartaConsentimiento(Cartaconsentimiento cc, string numExp)
        {
            try
            {
                var id = context.Fichaidentificacions.Where(f => f.FkPaciente == numExp)
                .Select(fi => fi.IdFicha).First();
                cc.FkFicha = id;
                context.Cartaconsentimientos.Add(cc);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getCartaConsentimiento(string expediente)
        {
            try
            {
                var id = context.Fichaidentificacions.Where(f => f.FkPaciente == expediente)
                .Select(fi => fi.IdFicha).First();

                return context.Cartaconsentimientos.Where(c => c.FkFicha == id).Select(cc => new {
                    FkFicha = cc.FkFicha,
                    FkHospital = cc.FkHospital,
                    FechaHora = cc.FechaHora,
                    FkConsejeria = cc.FkConsejeria,
                    Testigo1 = cc.Testigo1,
                    Testigo2 = cc.Testigo2,
                    FkDoctor = cc.FkDoctor
                }).First();

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public object getFichaMedica(string expediente)
        {
            try
            {
                return context.Fichaidentificacions.Where(f => f.FkPaciente == expediente).Select(fi => new {
                    IdFicha = fi.IdFicha,
                    FkPaciente = fi.FkPaciente,
                    Servicio = fi.Servicio,
                    Diagnostico = fi.Diagnostico
                }).First();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateCartaConsentimiento(Cartaconsentimiento cc)
        {
            try
            {
                var dbDatos = context.Cartaconsentimientos.Where(c => c.FkFicha == cc.FkFicha).First();
                
                if (!Utils.isTheSame(dbDatos.FkHospital, cc.FkHospital)) dbDatos.FkHospital = cc.FkHospital;
                if (!Utils.isTheSame(dbDatos.FechaHora, cc.FechaHora)) dbDatos.FechaHora = cc.FechaHora;
                if (!Utils.isTheSame(dbDatos.FkConsejeria, cc.FkConsejeria)) dbDatos.FkConsejeria = cc.FkConsejeria;
                if (!Utils.isTheSame(dbDatos.Testigo1, cc.Testigo1)) dbDatos.Testigo1 = cc.Testigo1;
                if (!Utils.isTheSame(dbDatos.Testigo2, cc.Testigo2)) dbDatos.Testigo2 = cc.Testigo2;
                if (!Utils.isTheSame(dbDatos.FkDoctor, cc.FkDoctor)) dbDatos.FkDoctor = cc.FkDoctor;

                context.SaveChanges();

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}