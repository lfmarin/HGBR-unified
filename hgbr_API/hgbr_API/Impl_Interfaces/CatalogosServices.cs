using System.Linq;
using hgbr_API.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class CatalogosServices : hgbr_API.Interfaces.ICatalogosServices
    {
        private readonly HgbrContext context;
        public CatalogosServices(HgbrContext context)
        {
            this.context = context;
        }
        public IQueryable<object> getAllEstadoConyugal()
        {
            try
            {
                return context.EstadoConyugals.Select(item => new
                {
                    idEstadoConyugal = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IQueryable<object> getAllTipoAsentamiento()
        {
            try
            {
                return context.TipoAsentamientos.Select(item => new
                {
                    idTipoAsentamiento = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IQueryable<object> getAllTipoVialidad()
        {
            try
            {
                return context.TipoVialidads.Select(item => new {
                    idTipoVialidad = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public IQueryable<object> getAllSexo()
        {
            try
            {
                return context.Sexos.Select(item => new {
                    idSexo = item.Id,
                    nombre = item.Nombre
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}