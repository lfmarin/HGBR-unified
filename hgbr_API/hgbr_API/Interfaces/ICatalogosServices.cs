using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface ICatalogosServices
{
    IQueryable<object> getAllEstadoCivil();
    IQueryable<object> getAllTipoAsentamiento();
    IQueryable<object> getAllTipoVialidad();
    IQueryable<object> getAllSexo();
    IQueryable<object> getAllEstado();
}