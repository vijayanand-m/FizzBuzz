namespace FizzBuzz.Mapper
{
    using AutoMapper;
    using FizzBuzz.Entities;
    using FizzBuzz.Models;

    /// <summary>
    /// Mapper class to map the Viewmodel from Entity.
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper"/> class.
        /// </summary>
        public Mapper()
        {
        }

        /// <summary>
        /// Maps the entity value to View model of FizzBuzz.
        /// </summary>
        /// <param name="serviceResponse">DivisibleNumberResponse entity.</param>
        /// <returns>Mapped FizzBuzzViewModel.</returns>
        public FizzBuzzViewModel FizzBuzzEntityToViewModelMapper(EvaluateServiceEntityResponse serviceResponse)
        {
            FizzBuzzViewModel viewModel = new FizzBuzzViewModel();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EvaluateServiceEntityResponse, FizzBuzzViewModel>().ForMember(
                destination => destination.EvaluatedValue, map => map.MapFrom(source => source.FizzBuzzResults));
            });
            IMapper mapper = mapConfig.CreateMapper();
            viewModel = mapper.Map<EvaluateServiceEntityResponse, FizzBuzzViewModel>(serviceResponse);
            return viewModel;
        }
    }
}