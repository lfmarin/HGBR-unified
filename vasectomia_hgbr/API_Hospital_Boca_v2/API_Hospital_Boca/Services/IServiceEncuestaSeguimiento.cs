using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceEncuestaSeguimeinto
    {
        void saveEncuestaSeguimeinto(Encuestaseguimiento es);
        void updateEncuestaSeguimiento(Encuestaseguimiento es);
        object getEncuestaSeguimientoByNumExp(string numExp);
        Encuestaseguimiento getEncuestaClassSeguimientoByNumExp(string numExp);
    }
}