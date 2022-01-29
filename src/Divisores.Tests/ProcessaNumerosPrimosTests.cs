using NUnit.Framework;
using Divisores.Processamento;
using System.Collections.Generic;
using Divisores.Application.Contracts;

namespace Divisores.Tests;

public class ProcessaNumerosPrimosTests
{
  private IProcessaNumerosPrimos _processaNumerosPrimos;

  [SetUp]
  public void Setup()
  {
    _processaNumerosPrimos = new ProcessaNumerosPrimos();
  }

  [Test]
  public void ProcessaNumerosPrimos_Comparar_Lista_Primos_Com_Primos_Gerados()
  {
    // Arrange
    var listaPrimos = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
    var listaPrimosGerado = new List<int>();

    // Action
    for (int i = 0; i < listaPrimos.Count; i++)
    {
      listaPrimosGerado.Add(_processaNumerosPrimos.Numero);
      _processaNumerosPrimos.Proximo();
    }

    // Assert
    Assert.That(listaPrimos, Is.EqualTo(listaPrimosGerado));
  }

  [Test]
  public void ProcessaNumerosPrimos_EhNumeroPrimo_Informado_0_Retorna_Falso()
  {
    // Arrange & Action
    var ehPrimo = _processaNumerosPrimos.EhNumeroPrimo(0);

    //Assert
    Assert.That(!ehPrimo);
  }

  [Test]
  public void ProcessaNumerosPrimos_EhNumeroPrimo_Informado_1_Retorna_True_Mas_Nao_Primo_()
  {
    // Arrange & Action
    var ehPrimo = _processaNumerosPrimos.EhNumeroPrimo(1);

    //Assert
    Assert.That(ehPrimo);
  }
}

