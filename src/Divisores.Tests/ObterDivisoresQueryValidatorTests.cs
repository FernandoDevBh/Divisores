using NUnit.Framework;
using FluentValidation.TestHelper;
using Divisores.Application.Features.Numero.Queries.ObterDivisores;

namespace Divisores.Tests;
public class ObterDivisoresQueryValidatorTests
{
  private ObterDivisoresQueryValidator _validator;

  [SetUp]
  public void Setup()
  {
    _validator = new ObterDivisoresQueryValidator();
  }

  [Test]
  public void Dever_Haver_Erros_Quando_Numero_Igual_Zero()
  {
    // Arrange
    var query = new ObterDivisoresQuery { Numero = 0 };    

    // Action
    var result = _validator.TestValidate(query);

    // Assert
    result.ShouldHaveValidationErrorFor(q => q.Numero);
  }
}
