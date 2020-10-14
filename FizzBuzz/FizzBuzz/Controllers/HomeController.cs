namespace FizzBuzz.Controllers
{
    using System.Web.Mvc;
    using FizzBuzz.Interface;
    using FizzBuzz.Mapper;
    using FizzBuzz.Models;

    [HandleError]
    public class HomeController : Controller
    {
        private IEvaluateService evaluateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="evaluationService"></param>
        public HomeController(IEvaluateService evaluationService)
        {
            this.evaluateService = evaluationService;
        }

        /// <summary>
        /// Get method for FizzBuzz evaluation.
        /// </summary>
        /// <returns>empty view.</returns>
        [HttpGet]
        public ActionResult FizzBuzz()
        {
            var viewModel = new FizzBuzzViewModel();
            return this.View(viewModel);
        }

        /// <summary>
        /// Post method for FizzBuzz Evaluation.
        /// </summary>
        /// <param name="viewModel">FizzBuzzViewModel.</param>
        /// <returns>Action result to the view with updated viewmodel.</returns>
        [HttpPost]
        public ActionResult FizzBuzz(FizzBuzzViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var mapper = new Mapper();

                // Get the Number evaluated based on the Fizz Buzz rules.
                var serviceResponse = this.evaluateService.GetEvaluatedFizzBuzzResults(viewModel.NumberToEvaluate);

                // Map the entity respone to view model.
                viewModel = mapper.FizzBuzzEntityToViewModelMapper(serviceResponse);
            }

            return this.View(viewModel);
        }
    }
}