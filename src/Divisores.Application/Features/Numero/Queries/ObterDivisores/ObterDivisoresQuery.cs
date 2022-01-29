using MediatR;

namespace Divisores.Application.Features.Numero.Queries.ObterDivisores;

public class ObterDivisoresQuery : IRequest<ResultadoDivisoresDto>
{
  public int Numero { get; set; }
}

