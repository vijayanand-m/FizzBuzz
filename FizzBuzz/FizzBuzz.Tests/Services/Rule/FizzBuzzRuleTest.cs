namespace FizzBuzz.Tests.Services
{
    using FizzBuzz.Interface;
    using FizzBuzz.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class FizzBuzzRuleTest
    {

        private FizzBuzzRule service;
        private Mock<IDayProviderService> mockDayProviderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzRuleTest"/> class.
        /// </summary>
        public FizzBuzzRuleTest()
        {
            this.mockDayProviderService = new Mock<IDayProviderService>();
            this.service = new FizzBuzzRule(this.mockDayProviderService.Object);
        }

        /// <summary>
        /// Test to check the FizzBuzz rule.
        /// </summary>
        [TestMethod]
        public void CheckFizzBuzzRuleOnWednesdayTest()
        {
            int numberToTest = 15;
            this.mockDayProviderService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.FIZZBUZZ)).Returns(ServiceConstants.WIZZWUZZ);

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            this.mockDayProviderService.Verify(z => z.TransformResultByDayCheck(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(ServiceConstants.WIZZWUZZ, testResult);
        }

        /// <summary>
        /// Test to check FizzBuzz rule.
        /// </summary>
        [TestMethod]
        public void CheckFizzBuzzRuleFailTest()
        {
            int numberToTest = 5;

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            Assert.AreEqual(numberToTest.ToString(), testResult);
        }
    }
}
