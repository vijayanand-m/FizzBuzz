namespace FizzBuzz.Interface
{
    using FizzBuzz.Entities;

    /// <summary>
    /// Interface to functions in EvaluateService to evaluate the given number.
    /// </summary>
    public interface IEvaluateService
    {
        EvaluateServiceEntityResponse GetEvaluatedFizzBuzzResults(int numberLimit);
    }
}
