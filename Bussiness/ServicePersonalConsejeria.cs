using System.Linq;
using API_Hospital_Boca.Utilities;
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

        public object getOnePersonalConsejeria(int idPersonal)
        {
            try
            {
                return context.Personalconsejeria.Where(p => p.IdPersonal == idPersonal).Select(per => new {
                    IdPersonal = per.IdPersonal,
                    Nombre = per.Nombre,
                    ApPaterno = per.ApPaterno,
                    ApMaterno = per.ApMaterno
                }).First();
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

        public void updatePersonalConsejeria(Personalconsejerium pc)
        {
            try
            {
                Personalconsejerium old = context.Personalconsejeria.Where(p => p.IdPersonal == pc.IdPersonal).First();

                if (!Utils.isTheSame(old.Nombre, pc.Nombre)) old.Nombre = pc.Nombre;
                if (!Utils.isTheSame(old.ApPaterno, pc.ApPaterno)) old.ApPaterno = pc.ApPaterno;
                if (!Utils.isTheSame(old.ApMaterno, pc.ApMaterno)) old.ApMaterno = pc.ApMaterno;

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}