using Divisores.Application.Contracts;

namespace Divisores.Processamento;

public class ProcessaNumerosPrimos : IProcessaNumerosPrimos
{
  private List<int> _numeros = new List<int>(10) { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
  private int _posicaoAtual;

  public ProcessaNumerosPrimos()
  {
    Reiniciar();
  }

  public int Numero { get => _numeros[_posicaoAtual]; }

  public void Proximo()
  {
    _posicaoAtual++;
    if (_posicaoAtual > (_numeros.Count - 1))
      _numeros.Add(GerarNumeroPrimo(_numeros.LastOrDefault()));
  }

  public void Reiniciar()
  {
    _posicaoAtual = 0;
  }

  private int GerarNumeroPrimo(int numero)
  {
    var proximoNumero = numero + 1;
    var ehPrimo = EhNumeroPrimo(proximoNumero);

    if (!ehPrimo)
      proximoNumero = GerarNumeroPrimo(proximoNumero);

    return proximoNumero;
  }

  public bool EhNumeroPrimo(int numero)
  {
    if (numero <= 0)
      return false;

    if (numero == 1)
      return true;

    for (var i = 2; i <= (numero / 2); i++)
    {
      if (numero % i == 0)
        return false;
    }
    return true;
  }
}
