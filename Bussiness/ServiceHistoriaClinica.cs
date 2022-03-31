using System.Linq;
using API_Hospital_Boca.Models;
using API_Hospital_Boca.Utilities;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceHistoriaClinica : API_Hospital_Boca.Services.IServiceHistoriaClinica
    {
        private readonly hospital_bocaContext context;
        public ServiceHistoriaClinica(hospital_bocaContext context)
        {
            this.context = context;
        }
        public void saveEstudioAnatomo(Estudioanatomo ea)
        {
            throw new System.NotImplementedException();
        }

        public void saveEvolucion(Evolucion ev)
        {
            throw new System.NotImplementedException();
        }

        public void saveHistoriaClinica(Historiaclinica hc)
        {
            try
            {
                context.Historiaclinicas.Add(hc);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveHistoriaExploracion(Historiaexploracion he)
        {
            throw new System.NotImplementedException();
        }

        public void saveMotivoSolicitud(Motivosolicitud ms)
        {
            try
            {
                context.Motivosolicituds.Add(ms);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveProcedimientoQuirurgico(Procquirurgico pq)
        {
            throw new System.NotImplementedException();
        }

        public void updateEstudioAnatomo(Estudioanatomo ea)
        {
            throw new System.NotImplementedException();
        }

        public void updateEvolucion(Evolucion ev)
        {
            throw new System.NotImplementedException();
        }

        public void updateHistoriaExploracion(Historiaexploracion he)
        {
            throw new System.NotImplementedException();
        }

        public void updateMotivoSolicitud(Motivosolicitud ms)
        {
            try
            {
                var res = context.Motivosolicituds.Where(msol => msol.FkHistoria == ms.FkHistoria).First();
                
                if (!Utils.isTheSame(ms.CausaNoHijos, res.CausaNoHijos)) res.CausaNoHijos = ms.CausaNoHijos;
                if (!Utils.isTheSame(ms.FkOpinion, res.FkOpinion)) res.FkOpinion = ms.FkOpinion;
                if (!Utils.isTheSame(ms.FkMetodoPlanificacion, res.FkMetodoPlanificacion)) res.FkMetodoPlanificacion = ms.FkMetodoPlanificacion;
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateProcedimeintoQuirurgico(Procquirurgico pq)
        {
            throw new System.NotImplementedException();
        }
    }
}