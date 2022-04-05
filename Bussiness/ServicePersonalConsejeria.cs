using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class ServicePersonalConsejeria : API_Hospital_Boca.Services.IServicePersonalConsejeria
    {

        private readonly hospital_bocaContext context;

        public ServicePersonalConsejeria(hospital_bocaContext context)
        {
            this.context = context;
        }
        public IQueryable<object> getAllPersonalConsejeria()
        {
            try
            {   
                return context.Personalconsejeria.Select(p => new {
                    IdPersonal = p.IdPersonal,
                    Nombre = p.Nombre,
                    ApPaterno = p.ApPaterno,
                    ApMaterno = p.ApMaterno
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void savePersonalConsejeria(Personalconsejerium pc)
        {
            try
            {
                context.Personalconsejeria.Add(pc);

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}