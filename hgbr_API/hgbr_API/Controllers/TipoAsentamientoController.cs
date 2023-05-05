using Microsoft.AspNetCore.Mvc;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using hgbr_API.ImplInterfaces;

namespace hgbr_API.controllers;

[ApiController]
[Route("[controller]")]
public class TipoAsentamientoController : ControllerBase
{
    private readonly ITipoAsentamientoServices _tipoAsentamientoServices;

    public TipoAsentamientoController(ITipoAsentamientoServices tipoAsentamientoServices)
    {
        this._tipoAsentamientoServices = tipoAsentamientoServices;
    }


    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<TipoAsentamiento>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var resultado = _tipoAsentamientoServices;
        return Ok(resultado);
    }

    [HttpGet("get/{idTipoAsentamiento}")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult specificDriver(int idTipoAsentamiento)
    {
        var resultado = _tipoAsentamientoServices.getTipoAsentamiento(idTipoAsentamiento);
        if (resultado == null)
            return NotFound();

        return Ok(resultado);
    }
}
