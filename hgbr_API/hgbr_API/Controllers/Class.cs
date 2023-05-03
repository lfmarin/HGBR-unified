using Microsoft.AspNetCore.Mvc;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using hgbr_API.ImplInterfaces;

namespace hgbr_API.controllers;

[ApiController]
[Route("[controller]")]
public class EstadoConyugalController : ControllerBase
{
    private readonly IEstadoConyugalServices _estadoConyugalService;

    public EstadoConyugalController(ISexoService _estadoConyugalService)
    {
        _estadoConyugalService = _estadoConyugalService;
    }

    /// <summary>
    /// Obtén todos los sexos registrados.
    /// </summary>
    [HttpGet("all")]
    // TODO: Una vez que terminemos de verificar que los datos de la base de datos
    [ProducesResponseType(typeof(IEnumerable<EstadoConyugal>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var resultado = _estadoConyugalService;
        return Ok(resultado);
    }

    [HttpGet("get/{idEstadoConyugal}")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult specificDriver(int idEstadoConyugal)
    {
        var resultado = _estadoConyugalService.getEstadoConyugal(idEstadoConyugal);
        if (resultado == null)
            return NotFound();

        return Ok(resultado);
    }
}