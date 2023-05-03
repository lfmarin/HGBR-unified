using Microsoft.AspNetCore.Mvc;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using hgbr_API.ImplInterfaces;
using backend.Models;

namespace hgbr_API.controllers;

[ApiController]
[Route("[controller]")]
public class SexoController : ControllerBase
{
	private readonly ISexoService _sexoService;

	public SexoController(ISexoService sexoService)
	{
		_sexoService = sexoService;
	}

	/// <summary>
	/// Obtén todos los sexos registrados.
	/// </summary>
	[HttpGet("all")]
	// TODO: Una vez que terminemos de verificar que los datos de la base de datos
	[ProducesResponseType(typeof(IEnumerable<Sexo>), StatusCodes.Status200OK)]
	public IActionResult Get()
	{
		var resultado = _sexoService.GetAll();
		return Ok(resultado);
	}

	/// <summary>
	/// Obtén los datos de un conductor en particular.
	/// </summary>
	/// <response code="404">No hay un conductor disponible que corresponda al ID. No lo confunda con el envio de un elemento no encontrado.</response>
	/// <response code="200">El conductor fue encontrado.</response>
	/// <returns>Conductor</returns>
	[HttpGet("get/{idSexo}")]
	[ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
	public IActionResult specificDriver(int idSexo)
	{
		var resultado = _sexoService.getSexo(idSexo);
		if (resultado == null)
			return NotFound();

		return Ok(resultado);
	}
}