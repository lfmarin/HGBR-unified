using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface IEstadoConyugalServices
{
	IEnumerable<EstadoConyugal> GetAll();
	string Registrar(EstadoConyugal est);
	string Eliminar(int ID);
	object? getEstadoConyugal(int ID);
	EstadoConyugal getEstadoConyugalClass(int ID);
}