namespace FizzBuzz.Services
{
    using FizzBuzz.Interface;

    public class BuzzRule : IRulesService
    {
        private int buzzNumber = 5;
        private bool isBuzzNumber;
        private IDayProviderService dayProviderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuzzRule"/> class.
        /// </summary>
        /// <param name="dayProvider"></param>
        public BuzzRule(IDayProviderService dayProvider)
        {
            this.dayProviderService = dayProvider;
        }

        /// <summary>
        /// Validate the given number is Buzz Number.
        /// </summary>
        /// <param name="number"> number to be validated.</param>
        /// <returns>evaluated result.</returns>
        public string CheckRuleAndGetResults(int number)
        {
            var buzzResult = number % this.buzzNumber == 0 ? this.dayProviderService.TransformResultByDayCheck(ServiceConstants.BUZZ) : number.ToString();
            return buzzResult;
        }
    }
}
