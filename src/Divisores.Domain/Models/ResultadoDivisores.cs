namespace Divisores.Domain.Models;

public class ResultadoDivisores
{
  public int Numero { get; set; }
  public List<int> NumerosDivisores { get; set; }
  public List<int> DivisoresPrimos { get; set; }

  public override string ToString()
  {
    return $"Número Fornecido: {Numero} \nDivisores: {string.Join(", ", NumerosDivisores)} \nDivisores Primos: {string.Join(", ", DivisoresPrimos)}";
  }
}

