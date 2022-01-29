using NUnit.Framework;
using Divisores.Processamento;
using Microsoft.Extensions.DependencyInjection;
using Divisores.Application.Contracts;

namespace Divisores.Tests;

public class ProcessamentoServicesExtensionsTests
{
  private IServiceCollection _services;

  [SetUp]
  public void Setup()
  {
    _services = new ServiceCollection();
  }

  [Test]
  public void AddProcessamentoServices_Tipos_Deve_Gerados_Devem_Ser_Iguais()
  {
    // Arrange
    _services.AddProcessamentoServices();
    var provider = _services.BuildServiceProvider();
    
    // Action
    var processaMultiplicadores = provider.GetRequiredService<IProcessaMultiplicadores>();
    var processaNumerosPrimos = provider.GetRequiredService<IProcessaNumerosPrimos>();
    var processaDivisores = provider.GetRequiredService<IProcessaDivisores>();

    // Assert
    Assert.IsInstanceOf(typeof(ProcessaMultiplicadores), processaMultiplicadores);
    Assert.IsInstanceOf(typeof(ProcessaNumerosPrimos), processaNumerosPrimos);
    Assert.IsInstanceOf(typeof(ProcessaDivisores), processaDivisores);
  }
}

