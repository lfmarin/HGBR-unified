using System;
using hgbr_API.Interfaces;
using hgbr_API.Models;
namespace hgbr_API.ImplInterfaces
{
    public class EstadoConyugalService : IEstadoConyugalServices
    {
        private readonly HgbrContext context;

        public EstadoConyugalService(HgbrContext context)
        {
            this.context = context;
        }

        public EstadoConyugal getEstadoConyugalClass(int ID)
        {
            try
            {
                var lista = context.EstadoConyugals.Where(p => (int)p.Id == ID).FirstOrDefault();
                return lista;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getEstadoConyugal(int ID)
        {
            try
            {
                var result = context.EstadoConyugals.Where(p => (int)p.Id == ID).Select(escony => new
                {
                    idEstadoConyugal = escony.Id,
                    nombre = escony.Nombre
                }).First();
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IEnumerable<EstadoConyugal> GetAll()
        {
            try
            {
                var lista = context.EstadoConyugals.ToList();
                return lista.Select(es => {
                    return es;
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public string Registrar(EstadoConyugal est)
        {
            try
            {
                Console.WriteLine(est.ToString());

                if (context.EstadoConyugals.Where(p => p.Id == est.Id).Any())
                    // Ya existe el elemento, por lo tanto, no se puede realizar la insercion.
                    return "Ya existe un elemento con el mismo ID.";

                var done = context.EstadoConyugals.Add(est);
                context.SaveChanges();
                return "";
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return "Se encontro una Excepción !!!";
            }
        }
        public string Eliminar(int ID)
        {
            try
            {
                Console.WriteLine("Buscando estado con ID " + ID);
                EstadoConyugal aux = context.EstadoConyugals.Where(p => p.Id == ID).First();
                var done = context.EstadoConyugals.Remove(aux);
                context.SaveChanges();
                return "";
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return "No existe ese estado!!!";
            }
        }
    }
}