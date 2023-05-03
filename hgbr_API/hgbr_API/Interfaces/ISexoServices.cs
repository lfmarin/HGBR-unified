using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface ISexoService
{
	IEnumerable<Sexo> GetAll();
	// bool Registrar(Sexo sex);
	// string Eliminar(int ID);
	object getSexo(int ID);
	Sexo getSexoClass(int ID);
}

