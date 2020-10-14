namespace FizzBuzz.Services
{
    using FizzBuzz.Interface;

    public class FizzRule : IRulesService
    {
        private int fizzNumber = 3;
        private bool isFizzNumber;
        private IDayProviderService dayProviderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzRule"/> class.
        /// </summary>
        /// <param name="dayProvider"></param>
        public FizzRule(IDayProviderService dayProvider)
        {
            this.dayProviderService = dayProvider;
        }

        /// <summary>
        /// Validate the given number is Fizz Number.
        /// </summary>
        /// <param name="number"> number to be validated.</param>
        /// <returns>return evaluated result.</returns>
        public string CheckRuleAndGetResults(int number)
        {
            var fizzResult = number % this.fizzNumber == 0 ? this.dayProviderService.TransformResultByDayCheck(ServiceConstants.FIZZ) : number.ToString();
            return fizzResult;
        }
    }
}
