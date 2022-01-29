using System.Text;
using FluentValidation.Results;

namespace Divisores.Application.Excecoes
{
  public class ValidationException : ApplicationException
  {
    public ValidationException()
      : base("Uma ou mais falhas ocorreram na validação.")
    {

    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
      Errors = failures
          .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
          .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public string GetErros()
    {
      var details = new StringBuilder();
      foreach (var field in Errors.Keys)
      {
        details.AppendLine($"{field}:");
        details.AppendLine(string.Join(Environment.NewLine, Errors[field]));
      }
      return details.ToString();  
    }

    public IDictionary<string, string[]> Errors { get; }
  }
}
