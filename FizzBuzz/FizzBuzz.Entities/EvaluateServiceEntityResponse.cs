namespace FizzBuzz.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Entity to fill the data  from service response.
    /// </summary>
    public class EvaluateServiceEntityResponse
    {
        public Dictionary<int, string> FizzBuzzResults { get; set; }

        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluateServiceEntityResponse"/> class.
        /// </summary>
        public EvaluateServiceEntityResponse()
        {
            this.FizzBuzzResults = new Dictionary<int, string>();
        }
    }
}
