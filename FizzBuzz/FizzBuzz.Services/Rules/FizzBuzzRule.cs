namespace FizzBuzz.Services
{
    using FizzBuzz.Interface;

    public class FizzBuzzRule : IRulesService
    {
        private IDayProviderService dayProviderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzRule"/> class.
        /// </summary>
        /// <param name="dayProvider"></param>
        public FizzBuzzRule(IDayProviderService dayProvider)
        {
            this.dayProviderService = dayProvider;
        }

        /// <summary>
        /// Validate the given number is FizzBuzz Number.
        /// </summary>
        /// <param name="number"> number to be validated.</param>
        /// <returns>returns evaluated result.</returns>
        public string CheckRuleAndGetResults(int number)
        {
            var fizzBuzzNumber = number % 3 == 0 && number % 5 == 0 ? this.dayProviderService.TransformResultByDayCheck(ServiceConstants.FIZZBUZZ) : number.ToString();
            return fizzBuzzNumber;
        }
    }
}
