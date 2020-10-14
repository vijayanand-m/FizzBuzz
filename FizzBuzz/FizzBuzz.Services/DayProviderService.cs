namespace FizzBuzz.Services
{
    using System;
    using FizzBuzz.Interface;

    /// <summary>
    /// Service to provide the results based on the day.
    /// </summary>
    public class DayProviderService : IDayProviderService
    {

        /// <summary>
        /// Transforms the result based on the evaluated result.
        /// </summary>
        /// <param name="result">obtained result.</param>
        /// <returns>Transformed result.</returns>
        public string TransformResultByDayCheck(string result)
        {
            DayOfWeek todaysDay = DateTime.Now.DayOfWeek;
            string transformedResult = result;
            if (todaysDay == DayOfWeek.Wednesday)
            {
                switch (result.ToUpper())
                {
                    case ServiceConstants.FIZZ:
                        transformedResult = ServiceConstants.WIZZ;
                        break;
                    case ServiceConstants.BUZZ:
                        transformedResult = ServiceConstants.WUZZ;
                        break;
                    case ServiceConstants.FIZZBUZZ:
                        transformedResult = ServiceConstants.WIZZWUZZ;
                        break;
                }
            }

            return transformedResult;
        }
    }
}
