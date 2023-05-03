using System;
using hgbr_API.Models;
namespace hgbr_API.Interfaces;

public interface IPacienteService
{
	IEnumerable<Paciente> GetAll();
	bool Registrar(Paciente pac);
	string Eliminar(string folio);  //curp
	object? getPaciente(string folio);  //curp
	Paciente getPacienteClass(string folio);    //curp
}