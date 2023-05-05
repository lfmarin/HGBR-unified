using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface ITipoAsentamientoServices
{
	IEnumerable<TipoAsentamiento> GetAll();
	string Registrar(TipoAsentamiento asen);
	string Eliminar(int ID);
	object? getTipoAsentamiento(int ID);
	TipoAsentamiento getTipoAsentamientoClass(int ID);
}