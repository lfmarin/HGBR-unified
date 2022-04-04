using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceFichaIdentificacion
    {
        void saveFichaIdentificacion(Fichaidentificacion fi);
        void updateFichaIdentificacion(Fichaidentificacion fi);
    }
}