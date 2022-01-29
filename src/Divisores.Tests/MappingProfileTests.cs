using AutoMapper;
using NUnit.Framework;
using Divisores.API.Mappings;
using Divisores.Domain.Models;
using System.Collections.Generic;
using Divisores.Application.Features.Numero.Queries.ObterDivisores;

namespace Divisores.Tests
{
  public class MappingProfileTests
  {
    [Test]
    public void Configuracao_AutoMapper_EhValida()
    {
      // Arrange Action
      var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

      // Assert
      config.AssertConfigurationIsValid();
    }

    [Test]
    public void AutoMapper_Valores_Propriedades_Devem_Ser_Iguais()
    {
      // Arrange
      var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
      var mapper = config.CreateMapper();
      var resultado = new ResultadoDivisores
      {
        Numero = 90,
        NumerosDivisores = new List<int> { 1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 24, 30, 40, 60, 120 },
        DivisoresPrimos = new List<int> { 1,2,3,5 }
      };

      // Action
      var dto = mapper.Map<ResultadoDivisoresDto>(resultado);

      // Assert
      Assert.That(resultado.Numero, Is.EqualTo(dto.Numero));
      Assert.That(resultado.NumerosDivisores, Is.EquivalentTo(dto.NumerosDivisores));
      Assert.That(resultado.DivisoresPrimos, Is.EquivalentTo(dto.DivisoresPrimos));
    }
  }
}
