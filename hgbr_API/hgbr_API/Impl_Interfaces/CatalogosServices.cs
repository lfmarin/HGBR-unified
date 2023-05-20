//  El problema posiblemente provenga de la inyeccion de depedencias para que jale el context, debo checar eso con 
//  Varela
using System.Linq;
using hgbr_API.Interfaces;
using hgbr_API.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class CatalogosServices : ICatalogosServices
    {
        private readonly HospitalBocaContext context;
        public CatalogosServices(HospitalBocaContext context)
        {
            this.context = context;
        }

        //  Se esta intentando consumir la informacion de la BD con la implementacion de estos metodos
        public IQueryable<object> getAllEstadoConyugal()
        {
            try
            {
                return context.Estadocivils.Select(item => new
                {
                    idEstadoConyugal = item.IdEstadoCivil,
                    nombre = item.NombreEstado
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
                return context.Tipoasentamientos.Select(item => new
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
                return context.Tipovialidads.Select(item => new {
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

        public IQueryable<object> getAllEstado()
        {
            try
            {
                return context.Estados.Select(item => new {
                    idEstado = item.Id,
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