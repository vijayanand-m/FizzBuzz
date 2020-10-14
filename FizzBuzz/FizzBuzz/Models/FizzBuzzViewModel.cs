namespace FizzBuzz.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FizzBuzzViewModel
    {
        [Required]
        public int NumberToEvaluate { get; set; }

        public Dictionary<int, string> EvaluatedValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzViewModel"/> class.
        /// </summary>
        public FizzBuzzViewModel()
        {
            this.EvaluatedValue = new Dictionary<int, string>();
        }
    }
}