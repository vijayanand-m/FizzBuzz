namespace FizzBuzz.Tests.Services
{
    using System.Collections.Generic;
    using FizzBuzz.Interface;
    using FizzBuzz.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PrintServiceTest
    {
        private PrintService service;
        private Mock<IDayProviderService> mockDayService;
        private List<IRulesService> ruleList;
        private FizzRule fizzRule;
        private BuzzRule buzzRule;
        private FizzBuzzRule fizzBuzzRule;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintServiceTest"/> class.
        /// </summary>
        public PrintServiceTest()
        {
            this.ruleList = new List<IRulesService>();
            this.mockDayService = new Mock<IDayProviderService>();
            this.fizzRule = new FizzRule(this.mockDayService.Object);
            this.buzzRule = new BuzzRule(this.mockDayService.Object);
            this.fizzBuzzRule = new FizzBuzzRule(this.mockDayService.Object);
            this.ruleList.Add(this.fizzBuzzRule);
            this.ruleList.Add(this.fizzRule);
            this.ruleList.Add(this.buzzRule);
            this.service = new PrintService(this.ruleList);
        }

        /// <summary>
        /// Test to print the results post evaluation.
        /// </summary>
        [TestMethod]
        public void PrintResultTest()
        {
            int buzzNumber = 5;
            int fizzNumber = 3;
            int fizzBuzzNumber = 15;
            this.mockDayService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.FIZZ)).Returns(ServiceConstants.FIZZ);
            this.mockDayService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.BUZZ)).Returns(ServiceConstants.BUZZ);
            this.mockDayService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.FIZZBUZZ)).Returns(ServiceConstants.FIZZBUZZ);

            // Act
            var fizzResult = this.service.PrintResults(fizzNumber);
            var buzzResult = this.service.PrintResults(buzzNumber);
            var fizzBuzzResult = this.service.PrintResults(fizzBuzzNumber);

            // Assert
            this.mockDayService.Verify(z => z.TransformResultByDayCheck(It.IsAny<string>()), Times.AtLeastOnce);
            Assert.AreEqual(ServiceConstants.FIZZ, fizzResult);
            Assert.AreEqual(ServiceConstants.BUZZ, buzzResult);
            Assert.AreEqual(ServiceConstants.FIZZBUZZ, fizzBuzzResult);
        }

        /// <summary>
        /// Test to print the results for non divisble numbers post evaluation.
        /// </summary>
        [TestMethod]
        public void PrintResultNonDivisibleNumberTest()
        {
            int buzzNumber = 2;
            int fizzNumber = 4;
            int fizzBuzzNumber = 13;

            // Act
            var fizzResult = this.service.PrintResults(fizzNumber);
            var buzzResult = this.service.PrintResults(buzzNumber);
            var fizzBuzzResult = this.service.PrintResults(fizzBuzzNumber);

            // Assert
            Assert.AreEqual(fizzNumber.ToString(), fizzResult);
            Assert.AreEqual(buzzNumber.ToString(), buzzResult);
            Assert.AreEqual(fizzBuzzNumber.ToString(), fizzBuzzResult);
        }
    }
}
