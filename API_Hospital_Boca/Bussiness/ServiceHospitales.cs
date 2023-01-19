using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceHospitales : API_Hospital_Boca.Services.IServiceHospitales
    {
        private readonly hospital_bocaContext context;
        public ServiceHospitales(hospital_bocaContext context)
        {
            this.context = context;
        }

        public IQueryable<object> getAll()
        {
            try
            {
                return context.Hospitales.Select(h => new {
                    IdHospital = h.IdHospital,
                    EntidadFederativa = h.EntidadFederativa,
                    JurSanitaria = h.JurSanitaria,
                    UMedica = h.UMedica
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Hospitale getHospital(int idHospital)
        {
            try
            {
                return context.Hospitales.Where(p => p.IdHospital == idHospital).First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveHospital(Hospitale hos)
        {
            try
            {
                context.Hospitales.Add(hos);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}