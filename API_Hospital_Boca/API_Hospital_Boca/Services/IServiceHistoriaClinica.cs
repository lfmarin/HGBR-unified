using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceHistoriaClinica
    {
        void saveHistoriaClinica(Historiaclinica hc);
        void saveMotivoSolicitud(Motivosolicitud ms);
        void updateMotivoSolicitud(Motivosolicitud ms);
        void saveHistoriaExploracion(Historiaexploracion he);
        void updateHistoriaExploracion(Historiaexploracion he);
        void saveProcedimientoQuirurgico(Procquirurgico pq);
        void updateProcedimeintoQuirurgico(Procquirurgico pq);
        void saveEstudioAnatomo(Estudioanatomo ea);
        void updateEstudioAnatomo(Estudioanatomo ea);
        void saveEvolucion(Evolucion ev);
        void updateEvolucion(Evolucion ev);
        Historiaclinica getHistoriaClassByNumExp(string numExpe);
        object getHistoriaByNumExp(string numExpe);
        Motivosolicitud getClassMotivo(int idHistoria);
        object getMotivoSolicitudByIdHist(int idHistoria);
        object getHistoriaexploracionByIdHist(int idHistoria);
        object getProcedimientoQuirurgicoByIdHist(int idHistoria);
        object getEstudioAnatomo(int idHistoria);
        object getEvolucionByIdHist(int idHistoria);
    }
}