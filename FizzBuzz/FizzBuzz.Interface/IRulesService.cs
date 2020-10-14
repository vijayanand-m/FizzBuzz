namespace FizzBuzz.Interface
{
    /// <summary>
    /// Interface to functions in RulesService to evaluate the fizzbuzz rule.
    /// </summary>
    public interface IRulesService
    {
        string CheckRuleAndGetResults(int number);
    }
}
