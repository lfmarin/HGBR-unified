using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface ITipoVialidadServices
{
	IEnumerable<TipoVialidad> GetAll();
	bool Registrar(TipoVialidad est);
	string Eliminar(int ID);
	object? getTipoVialidad(int ID);
	TipoVialidad getTipoVialidadClass(int ID);
}