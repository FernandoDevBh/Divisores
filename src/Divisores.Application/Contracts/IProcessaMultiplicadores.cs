namespace Divisores.Application.Contracts;

public interface IProcessaMultiplicadores
{
  List<int> ObterMultiplicadores();
  void Processar(int multiplicador);
}

