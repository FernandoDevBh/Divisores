using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Divisores.Application.Contracts;

namespace Divisores.Application.Features.Numero.Queries.ObterDivisores;

public class ObterDivisoresHandler : IRequestHandler<ObterDivisoresQuery, ResultadoDivisoresDto>
{
  private readonly IProcessaDivisores _processaDivisores;
  private readonly IMapper _mapper;
  private readonly ILogger<ObterDivisoresHandler> _logger;

  public ObterDivisoresHandler(IProcessaDivisores processaDivisores, IMapper mapper, ILogger<ObterDivisoresHandler> logger)
  {
    _processaDivisores = processaDivisores ?? throw new ArgumentNullException(nameof(processaDivisores));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  public async Task<ResultadoDivisoresDto> Handle(ObterDivisoresQuery request, CancellationToken cancellationToken)
  {
    var resultado = _processaDivisores.ObterDivisores(request.Numero);
    _logger.LogInformation(resultado.ToString());
    return await Task.FromResult(_mapper.Map<ResultadoDivisoresDto>(resultado));
  }
}

