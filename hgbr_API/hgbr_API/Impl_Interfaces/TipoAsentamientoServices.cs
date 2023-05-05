using hgbr_API.Interfaces;
using hgbr_API.Models;
namespace hgbr_API.ImplInterfaces
{
    public class TipoAsentamientoServices : ITipoAsentamientoServices
    {
        private readonly HgbrContext context;

        public TipoAsentamientoServices(HgbrContext context)
        {
            this.context = context;
        }

        public TipoAsentamiento getTipoAsentamientoClass(int ID)
        {
            try
            {
                var lista = context.TipoAsentamientos.Where(p => (int)p.Id == ID).FirstOrDefault();
                return lista;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getTipoAsentamiento(int ID)
        {
            try
            {
                var result = context.TipoAsentamientos.Where(p => (int)p.Id == ID).Select(asent => new
                {
                    idAsentamiento = asent.Id,
                    nombre = asent.Nombre
                }).First();
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IEnumerable<TipoAsentamiento> GetAll()
        {
            try
            {
                var lista = context.TipoAsentamientos.ToList();
                return lista.Select(a => {
                    return a;
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public string Registrar(TipoAsentamiento asent)
        {
            try
            {
                Console.WriteLine(asent.ToString());

                if (context.EstadoConyugals.Where(p => p.Id == asent.Id).Any())
                    return "Ya existe un elemento con el mismo ID.";

                var done = context.TipoAsentamientos.Add(asent);
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
                Console.WriteLine("Buscando el tipo de asnetamiento con el ID " + ID);
                TipoAsentamiento aux = context.TipoAsentamientos.Where(p => p.Id == ID).First();
                var done = context.TipoAsentamientos.Remove(aux);
                context.SaveChanges();
                return "";
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return "No existe ese tipo !!!";
            }
        }
    }
}