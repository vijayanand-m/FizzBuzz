namespace FizzBuzz.Tests.Services
{
    using FizzBuzz.Interface;
    using FizzBuzz.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class BuzzRuleTest
    {
        private BuzzRule service;
        private Mock<IDayProviderService> mockDayProviderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuzzRuleTest"/> class.
        /// </summary>
        public BuzzRuleTest()
        {
            this.mockDayProviderService = new Mock<IDayProviderService>();
            this.service = new BuzzRule(this.mockDayProviderService.Object);
        }

        /// <summary>
        /// Test to check the Buzz Rule on Wednesday.
        /// </summary>
        [TestMethod]
        public void CheckBuzzRuleOnWednesdayTest()
        {
            int numberToTest = 5;
            this.mockDayProviderService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.BUZZ)).Returns(ServiceConstants.WUZZ);

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            this.mockDayProviderService.Verify(z => z.TransformResultByDayCheck(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(ServiceConstants.WUZZ, testResult);
        }

        /// <summary>
        /// Test to check the Buzz Rule on Non Wednesday.
        /// </summary>
        [TestMethod]
        public void CheckBuzzRuleOnNonWednesdayTest()
        {
            int numberToTest = 5;
            this.mockDayProviderService.Setup(z => z.TransformResultByDayCheck(ServiceConstants.BUZZ)).Returns(ServiceConstants.BUZZ);

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            this.mockDayProviderService.Verify(z => z.TransformResultByDayCheck(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(ServiceConstants.BUZZ, testResult);
        }

        /// <summary>
        /// Test to check Buzz rule for non fizz number.
        /// </summary>
        [TestMethod]
        public void CheckBuzzRuleFailTest()
        {
            int numberToTest = 3;

            // Act
            var testResult = this.service.CheckRuleAndGetResults(numberToTest);

            // Assert
            Assert.AreEqual("3", testResult);
        }
    }
}
