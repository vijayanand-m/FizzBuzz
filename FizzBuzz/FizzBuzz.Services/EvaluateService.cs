namespace FizzBuzz.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FizzBuzz.Entities;
    using FizzBuzz.Interface;

    public class EvaluateService : IEvaluateService
    {
        private IPrintService printService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluateService"/> class.
        /// </summary>
        /// <param name="printServ"></param>
        public EvaluateService(IPrintService printServ)
        {
            this.printService = printServ;
        }

        /// <summary>
        ///  Check the given number for FizzBuzz and get the results.
        /// </summary>
        /// <param name="numberLimit"> num to evaluation</param>
        /// <returns>FizzBuzzEntityResponse.</returns>
        public EvaluateServiceEntityResponse GetEvaluatedFizzBuzzResults(int numberLimit)
        {
            var fizzBuzzEntity = new EvaluateServiceEntityResponse();
            try
            {
                var seqNumber = this.GetSequenceNumbers(numberLimit);
                if (seqNumber != null && seqNumber.Count() == 0)
                {
                    throw new Exception(ServiceConstants.SEQUENCE_NUMBER_EXCEPTION);
                }
                else
                {
                    foreach (var num in seqNumber)
                    {
                        var result = this.printService.PrintResults(num);
                        fizzBuzzEntity.FizzBuzzResults.Add(num, result);
                    }
                }
            }
            catch (Exception ex)
            {
                fizzBuzzEntity.ExceptionMessage = string.IsNullOrEmpty(ex.Message) ? ex.InnerException.ToString() : ex.Message;
            }

            return fizzBuzzEntity;
        }

        /// <summary>
        /// Based on the given number reterive the sequence of numbers for evaluation.
        /// </summary>
        /// <param name="givenNumber"> Input number.</param>
        /// <returns>List of Numbers from 1 to the given number.</returns>
        private List<int> GetSequenceNumbers(int givenNumber)
        {
            var seqNumber = Enumerable.Range(1, givenNumber);
            return seqNumber.ToList();
        }
    }
}
