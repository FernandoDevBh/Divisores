using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Divisores.Application;
using AutoMapper;

namespace Divisores.Tests;

public class ApplicationServicesExtensionsTests
{
  private IServiceCollection _services;

  [SetUp]
  public void Setup()
  {
    _services = new ServiceCollection();
  }

  [Test]
  public void AddApplicationServices_Tipos_Deve_Gerados_Devem_Ser_Iguais()
  {
    // Arrange
    _services.AddApplicationServices();
    var provider = _services.BuildServiceProvider();

    // Action
    var mapper = provider.GetRequiredService<IMapper>();

    // Assert
    Assert.IsInstanceOf<IMapper>(mapper);
  }
}

