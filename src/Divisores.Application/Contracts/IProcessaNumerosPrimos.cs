namespace Divisores.Application.Contracts;

public interface IProcessaNumerosPrimos
{
  int Numero { get; }

  bool EhNumeroPrimo(int numero);
  void Proximo();
  void Reiniciar();
}

