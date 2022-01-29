using MediatR;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Divisores.Application.Features.Numero.Queries.ObterDivisores;

namespace Divisores.API.Controllers;

[Route("api/v1/divisores")]
[ApiController]
public class DivisoresController : ControllerBase
{
  private readonly IMediator _mediator;

  public DivisoresController(IMediator mediator)
  {
    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
  }

  [HttpGet("{numero}", Name = "ObterDivisores")]
  [ResponseCache(CacheProfileName = "Default30")]
  [ProducesResponseType(typeof(ResultadoDivisoresDto), (int)HttpStatusCode.OK)]
  public async Task<IActionResult> ObterDivisores(int numero)
  {
    var resultado = await _mediator.Send(new ObterDivisoresQuery { Numero = numero });
    return Ok(resultado);
  }
}

