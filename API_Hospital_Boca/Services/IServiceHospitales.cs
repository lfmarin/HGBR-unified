using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServiceHospitales
    {
        IQueryable<object> getAll();
        void saveHospital(Hospitale hos);
    }
}