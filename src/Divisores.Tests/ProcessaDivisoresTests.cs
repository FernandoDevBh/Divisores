using NUnit.Framework;
using Divisores.Processamento;
using Divisores.Application.Contracts;
using System.Collections.Generic;

namespace Divisores.Tests;

public class ProcessaDivisoresTests
{
  private IProcessaDivisores _processaDivisores;

  [SetUp]
  public void Setup()
  {
    _processaDivisores = new ProcessaDivisores(new ProcessaNumerosPrimos(), new ProcessaMultiplicadores());
  }

  [Test]
  public void ProcessaDivisores_ObterDivisores_ListaDivisores_E_Primos_Deve_Ser_Iguais()
  {
    // Arrange
    var numerosDivisores = new List<int> { 1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 24, 30, 40, 60, 120 };
    var divisoresPrimos = new List<int> { 1, 2, 3, 5 };

    // action
    var resultado = _processaDivisores.ObterDivisores(120);

    // Assert
    Assert.That(numerosDivisores, Is.EquivalentTo(resultado.NumerosDivisores));
    Assert.That(divisoresPrimos, Is.EquivalentTo(resultado.DivisoresPrimos));
  }
}

