using System.Linq;

namespace API_Hospital_Boca.Services
{
    public interface IServiceCatalogos
    {
        IQueryable<object> getAllEstadoCivil();
        IQueryable<object> getAllEscolaridad();
        IQueryable<object> getAllOcupacion();
        IQueryable<object> getAllReligion();
        IQueryable<object> getAllLugarReferencia();
        IQueryable<object> getAllOpinionPareja();
        IQueryable<object> getAllMetodoPlanificacion();
        IQueryable<object> getAllCalidadServicio();
        IQueryable<object> getAllCalidadRelacion();
    }
}