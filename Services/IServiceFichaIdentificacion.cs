using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceFichaIdentificacion
    {
        void saveFichaIdentificacion(Fichaidentificacion fi);
        void updateFichaIdentificacion(Fichaidentificacion fi);
        object getFichaMedica(string expediente);
        void saveNotaMedica(Notamedica nm);
        IQueryable<object> getAllNotasMedicas(int numFicha);
        void saveCartaConsentimiento(Cartaconsentimiento cc, string numExp);
        object getCartaConsentimiento(string expediente);
        void updateCartaConsentimiento(Cartaconsentimiento cc);
    }
}