namespace FizzBuzz.Tests.Services
{
    using System;
    using FizzBuzz.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DayProviderServiceTest
    {
        private DayProviderService providerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DayProviderServiceTest"/> class.
        /// </summary>
        public DayProviderServiceTest()
        {
            this.providerService = new DayProviderService();
        }

        /// <summary>
        /// Test for checking the day and transforming the results.
        /// </summary>
        [TestMethod]
        public void TransformResultByDayCheckTest()
        {
            var day = DateTime.Now.DayOfWeek.ToString();
            bool iswednesday = day.ToUpper() == ServiceConstants.DAY ? true : false;
            var fizzResult = this.providerService.TransformResultByDayCheck(ServiceConstants.FIZZ);
            var buzzResult = this.providerService.TransformResultByDayCheck(ServiceConstants.BUZZ);
            var fizzBuzzResult = this.providerService.TransformResultByDayCheck(ServiceConstants.FIZZBUZZ);

            Assert.IsNotNull(fizzResult);
            Assert.IsNotNull(buzzResult);
            Assert.IsNotNull(fizzBuzzResult);
            if (iswednesday)
            {
                Assert.AreEqual(ServiceConstants.WIZZ, fizzResult);
                Assert.AreEqual(ServiceConstants.WUZZ, buzzResult);
                Assert.AreEqual(ServiceConstants.WIZZWUZZ, fizzBuzzResult);
            }
            else
            {
                Assert.AreEqual(ServiceConstants.FIZZ, fizzResult);
                Assert.AreEqual(ServiceConstants.BUZZ, buzzResult);
                Assert.AreEqual(ServiceConstants.FIZZBUZZ, fizzBuzzResult);
            }
        }

        /// <summary>
        /// Test for check if the empty values are handled.
        /// </summary>
        [TestMethod]
        public void TransformResultByDayFailTest()
        {
            var result = this.providerService.TransformResultByDayCheck(" ");
            Assert.IsNotNull(result);
            Assert.AreEqual(" ", result);
        }
    }
}
