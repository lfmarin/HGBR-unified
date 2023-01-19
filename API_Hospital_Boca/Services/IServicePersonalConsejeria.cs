using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServicePersonalConsejeria
    {
        IQueryable<object> getAllPersonalConsejeria();
        void savePersonalConsejeria(Personalconsejerium pc);
        object getOnePersonalConsejeria(int idPersonal);
        Personalconsejerium getClassPersonalConsejeria(int idPersonal);
        void updatePersonalConsejeria(Personalconsejerium pc);
    }
}