using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceCatalogos : API_Hospital_Boca.Services.IServiceCatalogos
    {
        private readonly hospital_bocaContext context; 
        public ServiceCatalogos(hospital_bocaContext context)
        {
            this.context = context;
        }
        public IQueryable<object> getAllCalidadRelacion()
        {
            try
            {
                return context.Calidadrelacions.Select(item => new {
                    IdCalidadRelacion = item.IdCalidadRelacion,
                    NombreCalidadRelacion = item.NombreCalidadRelacion
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllCalidadServicio()
        {
             try
            {
                return context.Calidadservicios.Select(item => new {
                    IdCalidad = item.IdCalidad,
                    NombreCalidad = item.NombreCalidad
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllEscolaridad()
        {
            try
            {
                return context.Escolaridads.Select(item => new {
                    idEscolaridad = item.IdEscolaridad,
                    NombreEscolaridad = item.NombreEscolaridad
                }); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllEstadoCivil()
        {
            try
            {
                return context.Estadocivils.Select(item => new {
                    IdEstadoCivil = item.IdEstadoCivil,
                    NombreEstado = item.NombreEstado
                });      
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllLugarReferencia()
        {
            try
            {
                return context.Lugarreferencia.Select(item => new {
                    IdLugar = item.IdLugar,
                    NombreLugar = item.NombreLugar
                });
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public IQueryable<object> getAllMetodoPlanificacion()
        {
            try
            {
                return context.Metodoplanificacions.Select(item => new {
                    IdMetodo = item.IdMetodo,
                    NombreMetodo = item.NombreMetodo
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllOcupacion()
        {
            try
            {
                return context.Ocupacions.Select(item => new {
                    IdOcupacion = item.IdOcupacion,
                    NombreOcupacion = item.NombreOcupacion
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IQueryable<object> getAllOpinionPareja()
        {
            try
            {
                return context.Opinionparejas.Select(item => new {
                    IdOpinion = item.IdOpinion,
                    NombreOpinion = item.NombreOpinion
                });
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        public IQueryable<object> getAllReligion()
        {
            try
            {
                return context.Religions.Select(item => new {
                    IdReligion = item.IdReligion,
                    NombreReligion = item.NombreReligion
                }); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
