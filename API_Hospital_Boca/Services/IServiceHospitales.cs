using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceHospitales
    {
        IQueryable<object> getAll();
        Hospitale getHospital(int idHospital);
        void saveHospital(Hospitale hos);
    }
}