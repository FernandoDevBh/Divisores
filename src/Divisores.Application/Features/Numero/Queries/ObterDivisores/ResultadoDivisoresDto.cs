namespace Divisores.Application.Features.Numero.Queries.ObterDivisores;

public class ResultadoDivisoresDto
{
  public int Numero { get; set; }
  public List<int> NumerosDivisores { get; set; }
  public List<int> DivisoresPrimos { get; set; }
}

