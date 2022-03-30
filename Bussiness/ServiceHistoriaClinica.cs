using System.Linq;
using API_Hospital_Boca.Models;

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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void updateProcedimeintoQuirurgico(Procquirurgico pq)
        {
            throw new System.NotImplementedException();
        }
    }
}