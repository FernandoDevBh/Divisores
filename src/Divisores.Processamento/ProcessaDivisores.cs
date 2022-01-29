using Divisores.Domain.Models;
using Divisores.Application.Contracts;

namespace Divisores.Processamento;

public class ProcessaDivisores : IProcessaDivisores
{
  private readonly IProcessaNumerosPrimos _primos;
  private readonly IProcessaMultiplicadores _multiplicadores;

  public ProcessaDivisores(IProcessaNumerosPrimos primos, IProcessaMultiplicadores multiplicadores)
  {
    _primos = primos ?? throw new ArgumentNullException(nameof(primos));
    _multiplicadores = multiplicadores ?? throw new ArgumentNullException(nameof(multiplicadores));
  }

  public ResultadoDivisores ObterDivisores(int numero)
  {
    ProcessarDivisores(numero);
    var divisores = _multiplicadores.ObterMultiplicadores();
    return new ResultadoDivisores
    {
      Numero = numero,
      NumerosDivisores = divisores,
      DivisoresPrimos = divisores.Where(n => _primos.EhNumeroPrimo(n)).ToList()
    };
  }

  private void ProcessarDivisores(int numero)
  {
    while (numero > 1)
    {
      if (numero % _primos.Numero == 0)
        numero = IncluirDivisores(numero);
      else
        _primos.Proximo();
    }
  }

  private int IncluirDivisores(int numero)
  {
    numero = numero / _primos.Numero;
    _multiplicadores.Processar(_primos.Numero);
    _primos.Reiniciar();
    return numero;
  }
}
