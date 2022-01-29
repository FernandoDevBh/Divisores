using NUnit.Framework;
using FluentValidation.Results;
using System.Collections.Generic;
using Divisores.Application.Excecoes;

namespace Divisores.Tests;

public class ValidationExceptionTests
{
  private IEnumerable<ValidationFailure> _failures;

  [SetUp]
  public void Setup()
  {
    _failures = new List<ValidationFailure> { new ValidationFailure("Numero", "Nùmero tem que ser maior que 0") };
  }

  [Test]
  public void DeveRetornar_String_Com_Mensagem_Erro()
  {
    // Arrange
    var validationException = new ValidationException(_failures);

    // Action
    var error = validationException.GetErros();

    // Assert
    Assert.IsNotEmpty(error);
  }
}
