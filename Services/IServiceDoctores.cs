using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceDoctores
    {
        IQueryable<object> getAll();
        void saveDoctor(Doctore d);
        void updateDoctor(Doctore d);
        void deleteDoctor(int idDoctor);
    }
}