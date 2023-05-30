using System;
using System.Linq;
using hgbr_API.Models;

namespace hgbr_API.Interfaces
{
    public interface IAdmisionesServices
    {
        IQueryable<object> getAll();
        Admisione getClassAdmisiones(int folio);
        object getAdmisiones(int folio);
        void saveAdmisiones(Admisione admision);
        void updateAdmisiones(Admisione admision);
        void deleteAdmisiones(int folio);
    }
}