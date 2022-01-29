using Divisores.Application.Contracts;

namespace Divisores.Processamento;

public class ProcessaMultiplicadores : IProcessaMultiplicadores
{
  private List<List<int>> _gruposDivisores;
  public ProcessaMultiplicadores()
  {
    _gruposDivisores = new List<List<int>>(1) { new List<int> { 1 } };
  }  

  public void Processar(int multiplicador)
  {
    var novoGrupo = new List<int>();
    foreach (var grupo in _gruposDivisores)
    {
      foreach (var numero in grupo)
      {
        novoGrupo.Add(multiplicador * numero);
      }
    }
    _gruposDivisores.Add(novoGrupo);
  }

  public List<int> ObterMultiplicadores()
  {
    var divisores = new List<int>();

    foreach (var grupo in _gruposDivisores)
      divisores.AddRange(grupo);

    return divisores.Distinct().OrderBy(n => n).ToList();
  }
}
