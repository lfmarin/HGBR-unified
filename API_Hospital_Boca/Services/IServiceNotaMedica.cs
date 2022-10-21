using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceNotaMedica
    {
        void saveNotaMedica(Notamedica nota);
        void updateNotaMedica(Notamedica nota);
        object getNotaMedicaByNumExp(string numExp);
    }
}