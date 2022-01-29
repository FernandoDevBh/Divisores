using NUnit.Framework;
using Divisores.Processamento;
using Divisores.Application.Contracts;
using System.Collections.Generic;

namespace Divisores.Tests;

public class ProcessaMultiplicadoresTests
{
  private IProcessaMultiplicadores _processaMultiplicadores;

  [SetUp]
  public void Setup()
  {
    _processaMultiplicadores = new ProcessaMultiplicadores();
  }

  [Test]
  public void ProcessaMultiplicadores_Ao_Gerar_ObterMultiplicadores_Itens_Devem_Ser_Iguais()
  {
    // Arrange
    var listaBase = new List<int> { 1, 2, 3, 6 };

    // Action
    _processaMultiplicadores.Processar(2);
    _processaMultiplicadores.Processar(3);

    // Arrange
    Assert.That(listaBase, Is.EquivalentTo(_processaMultiplicadores.ObterMultiplicadores()));
  }
}

