namespace FizzBuzz.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FizzBuzz.Interface;

    public class PrintService : IPrintService
    {
        private IEnumerable<IRulesService> rulesServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintService"/> class.
        /// </summary>
        /// <param name="rulesServ"> Inject the rules Service.</param>
        public PrintService(IEnumerable<IRulesService> rulesServ)
        {
            this.rulesServices = rulesServ;
        }

        /// <summary>
        /// Print the result based on the evalation of number.
        /// </summary>
        /// <param name="number">Is the number is Fizzbuzz.</param>
        /// <returns>returns the result string.</returns>
        public string PrintResults(int number)
        {
            var resultToPrint = number.ToString();
            foreach (var rules in this.rulesServices)
            {
                resultToPrint = rules.CheckRuleAndGetResults(number);
                if (resultToPrint != number.ToString())
                {
                    break;
                }
            }

            return resultToPrint;
        }
    }
}
