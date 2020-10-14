namespace FizzBuzz.Tests.Services
{
    using FizzBuzz.Entities;
    using FizzBuzz.Interface;
    using FizzBuzz.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class EvaluateServiceTest
    {
        private EvaluateService service;
        private Mock<IPrintService> mockPrintService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluateServiceTest"/> class.
        /// </summary>
        public EvaluateServiceTest()
        {
            this.mockPrintService = new Mock<IPrintService>();
            this.service = new EvaluateService(this.mockPrintService.Object);
        }

        /// <summary>
        /// Test to GetEvaluatedFizzBuzzResults.
        /// </summary>
        [TestMethod]
        public void GetEvaluatedFizzBuzzResultsTest()
        {
            int[] fizzList = { 3, 6, 9, 12 };
            int[] buzzList = { 5, 10 };
            int[] remainingNumbers = { 1, 2, 4, 7, 8, 11, 13, 14 };
            var mockResponse = new EvaluateServiceEntityResponse();

            mockResponse.FizzBuzzResults.Add(1, "1");
            mockResponse.FizzBuzzResults.Add(2, "2");
            mockResponse.FizzBuzzResults.Add(3, "FIZZ");
            mockResponse.FizzBuzzResults.Add(4, "4");
            mockResponse.FizzBuzzResults.Add(5, "BUZZ");
            mockResponse.FizzBuzzResults.Add(6, "FIZZ");
            mockResponse.FizzBuzzResults.Add(7, "7");
            mockResponse.FizzBuzzResults.Add(8, "8");
            mockResponse.FizzBuzzResults.Add(9, "FIZZ");
            mockResponse.FizzBuzzResults.Add(10, "BUZZ");
            mockResponse.FizzBuzzResults.Add(11, "11");
            mockResponse.FizzBuzzResults.Add(12, "FIZZ");
            mockResponse.FizzBuzzResults.Add(13, "13");
            mockResponse.FizzBuzzResults.Add(14, "14");
            mockResponse.FizzBuzzResults.Add(15, "FIZZBUZZ");

            foreach (var fizzNum in fizzList)
            {
                this.mockPrintService.Setup(y => y.PrintResults(fizzNum)).Returns(ServiceConstants.FIZZ);
            }

            foreach (var buzzNum in buzzList)
            {
                this.mockPrintService.Setup(y => y.PrintResults(buzzNum)).Returns(ServiceConstants.BUZZ);
            }

            foreach (var num in remainingNumbers)
            {
                this.mockPrintService.Setup(y => y.PrintResults(num)).Returns(num.ToString());
            }

            this.mockPrintService.Setup(y => y.PrintResults(15)).Returns(ServiceConstants.FIZZBUZZ);

            // Act
            var result = this.service.GetEvaluatedFizzBuzzResults(15) as EvaluateServiceEntityResponse;

            this.mockPrintService.Verify(z => z.PrintResults(It.IsAny<int>()), Times.Exactly(15));

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(mockResponse.FizzBuzzResults, result.FizzBuzzResults);
        }

        /// <summary>
        /// Test to validate if the exceptions are hanled in GetEvaluatedFizzBuzzResults.
        /// </summary>
        [TestMethod]
        public void GetEvaluatedFizzBuzzResultsExceptionTest()
        {
            var result = this.service.GetEvaluatedFizzBuzzResults(0) as EvaluateServiceEntityResponse;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ExceptionMessage);
            Assert.AreEqual(ServiceConstants.SEQUENCE_NUMBER_EXCEPTION, result.ExceptionMessage);
        }
    }
}
