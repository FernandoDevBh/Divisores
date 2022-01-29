using AutoMapper;
using Divisores.API.Mappings;
using Divisores.Application.Contracts;
using Divisores.Application.Features.Numero.Queries.ObterDivisores;
using Divisores.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Divisores.Tests
{
  public class ObterDivisoresHandlerTests
  {
    private ObterDivisoresHandler _handler;    

    [SetUp]
    public void Setup()
    {
      var mockDivisores = new Mock<IProcessaDivisores>();
      mockDivisores.Setup(x => x.ObterDivisores(120)).Returns(GerarDivisores());

      var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

      var mockLogger = new Mock<ILogger<ObterDivisoresHandler>>();

      _handler = new ObterDivisoresHandler(mockDivisores.Object, mapper, mockLogger.Object);
    }

    [Test]
    public void Handler_Deve_Gerar_Resultado_Diferente_Nulo()
    {
      // Arrange
      var query = new ObterDivisoresQuery { Numero = 120 };

      // Action
      var result = _handler.Handle(query, new CancellationToken()).Result;

      // Assert
      Assert.IsNotNull(result);
    }

    private ResultadoDivisores GerarDivisores() =>
      new ResultadoDivisores
      {
        Numero = 120,
        NumerosDivisores = new List<int> { 1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 24, 30, 40, 60, 120 },
        DivisoresPrimos = new List<int> { 1, 2, 3, 5 }
      }; 
  }
}
