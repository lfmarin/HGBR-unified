using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServicePersonalConsejeria
    {
        IQueryable<object> getAllPersonalConsejeria();
        void savePersonalConsejeria(Personalconsejerium pc);
    }
}