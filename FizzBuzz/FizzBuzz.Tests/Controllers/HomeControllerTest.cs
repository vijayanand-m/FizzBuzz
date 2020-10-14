namespace FizzBuzz.Tests.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using FizzBuzz.Controllers;
    using FizzBuzz.Entities;
    using FizzBuzz.Interface;
    using FizzBuzz.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IEvaluateService> mockEvaluateService;
        private HomeController controller;

        public HomeControllerTest()
        {
            this.mockEvaluateService = new Mock<IEvaluateService>();
            this.controller = new HomeController(this.mockEvaluateService.Object);
        }

        [TestMethod]
        public void FizzBuzzGetTest()
        {
            ViewResult result = this.controller.FizzBuzz() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FizzBuzzEvaluationTest()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EvaluateServiceEntityResponse, FizzBuzzViewModel>().
                ForMember(
                    destination => destination.EvaluatedValue,
                    map => map.MapFrom(source => source.FizzBuzzResults));
            });
            IMapper mapper = config.CreateMapper();
            FizzBuzzViewModel mockViewModel = new FizzBuzzViewModel();
            EvaluateServiceEntityResponse mockResponse = new EvaluateServiceEntityResponse();
            mockViewModel.NumberToEvaluate = 15;
            mockResponse.FizzBuzzResults.Add(1, "1");
            mockResponse.FizzBuzzResults.Add(2, "2");
            mockResponse.FizzBuzzResults.Add(4, "4");
            mockResponse.FizzBuzzResults.Add(5, "Buzz");
            mockResponse.FizzBuzzResults.Add(6, "Fizz");
            mockResponse.FizzBuzzResults.Add(7, "7");
            mockResponse.FizzBuzzResults.Add(8, "8");
            mockResponse.FizzBuzzResults.Add(9, "Fizz");
            mockResponse.FizzBuzzResults.Add(10, "Buzz");
            mockResponse.FizzBuzzResults.Add(11, "11");
            mockResponse.FizzBuzzResults.Add(12, "Fizz");
            mockResponse.FizzBuzzResults.Add(13, "13");
            mockResponse.FizzBuzzResults.Add(14, "14");
            mockResponse.FizzBuzzResults.Add(15, "FizzBuzz");

            this.mockEvaluateService.Setup(x => x.GetEvaluatedFizzBuzzResults(It.IsAny<int>())).Returns(mockResponse);

            //Act
            ViewResult result = this.controller.FizzBuzz(mockViewModel) as ViewResult;

            this.mockEvaluateService.Verify(x => x.GetEvaluatedFizzBuzzResults(It.IsAny<int>()), Times.Once);
            mockViewModel = mapper.Map<EvaluateServiceEntityResponse, FizzBuzzViewModel>(mockResponse);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);

            FizzBuzzViewModel viewModel = result.Model as FizzBuzzViewModel;
            CollectionAssert.AreEqual(mockViewModel.EvaluatedValue, viewModel.EvaluatedValue);
        }
    }
}
