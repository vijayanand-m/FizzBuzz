namespace FizzBuzz.Tests.Services
{
    using FizzBuzz.Interface;
    using FizzBuzz.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class FizzRuleTest
    {
        private FizzRule service;
        private Mock<IDayProviderService> mockDayProviderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzRuleTest"/> class.
        /// </summary>
        public FizzRuleTest()
        {
            this.mockDayProviderService = new Mock<IDayProviderService>();
            this.service = new FizzRule(this.mockDayProviderService.Object);
        }

        /// <summary>
        /// Test to check the Fizz Rule on Wednesday.
        /// </summary>
        [TestMethod]
        public void CheckFizzRuleOnWednesdayTest()
        {
            int numberToTest = 3;
            this.mockDayProviderService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.FIZZ)).Returns(ServiceConstants.WIZZ);

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            this.mockDayProviderService.Verify(z => z.TransformResultByDayCheck(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(ServiceConstants.WIZZ, testResult);
        }

        /// <summary>
        /// Test to check the Fizz Rule on Non Wednesday.
        /// </summary>
        [TestMethod]
        public void CheckFizzRuleOnNonWednesdayTest()
        {
            int numberToTest = 3;
            this.mockDayProviderService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.FIZZ)).Returns(ServiceConstants.FIZZ);

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            this.mockDayProviderService.Verify(z => z.TransformResultByDayCheck(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(ServiceConstants.FIZZ, testResult);
        }

        /// <summary>
        /// Test to check Fizz rule for non fizz number.
        /// </summary>
        [TestMethod]
        public void CheckFizzRuleFailTest()
        {
            int numberToTest = 5;

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            Assert.AreEqual(numberToTest.ToString(), testResult);
        }
    }
}
