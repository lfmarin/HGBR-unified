using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceDoctores : API_Hospital_Boca.Services.IServiceDoctores
    {
        private readonly hospital_bocaContext context;
        public ServiceDoctores (hospital_bocaContext context) 
        {
            this.context = context;
        }

        public void deleteDoctor(int idDoctor)
        {
            try
            {
                Doctore doc = context.Doctores.Where(d => d.IdDoctor == idDoctor).First();
                context.Doctores.Remove(doc);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAll()
        {
            try
            {
                return context.Doctores.Select(d => new {
                    IdDoctor = d.IdDoctor,
                    Nombre = d.Nombre,
                    ApPaterno = d.ApPaterno,
                    ApMaterno = d.ApMaterno
                });
            }
            catch (System.Exception)
            {
                throw;
            }
            throw new System.NotImplementedException();
        }

        public object getDoctor(int idDoctor)
        {
            try
            {
                return context.Doctores.Where(d => d.IdDoctor == idDoctor).Select(doc => new {
                    IdDcotor = doc.IdDoctor,
                    Nombre = doc.Nombre,
                    ApPaterno = doc.ApPaterno,
                    ApMaterno = doc.ApMaterno
                }).First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveDoctor(Doctore d)
        {
            try
            {
                context.Doctores.Add(d);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateDoctor(Doctore d)
        {
            try
            {
                Doctore aux = context.Doctores.Where(doc => doc.IdDoctor == d.IdDoctor).First();

                if (!aux.Nombre.Equals(d.Nombre)) aux.Nombre = d.Nombre;
                if (!aux.ApPaterno.Equals(d.ApPaterno)) aux.ApPaterno = d.ApPaterno;
                if (!aux.ApMaterno.Equals(d.ApMaterno)) aux.ApMaterno = d.ApMaterno;

                context.SaveChanges();
            }
            catch (System.Exception)
            {   
                throw;
            }
        }
    }
}
