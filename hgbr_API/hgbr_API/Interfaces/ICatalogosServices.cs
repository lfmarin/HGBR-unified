using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface ICatalogosServices
{
    IQueryable<object> getAllEstadoConyugal();
    IQueryable<object> getAllTipoAsentamiento();
    IQueryable<object> getAllTipoVialidad();
    IQueryable<object> getAllSexo();
}