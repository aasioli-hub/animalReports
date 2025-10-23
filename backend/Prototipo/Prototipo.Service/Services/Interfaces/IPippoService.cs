using Prototipo.Api.Model;

namespace Prototipo.Api.Services.Interfaces
{
    public interface IPippoService
    {
        void Add(PippoDTO addEntity);

        List<WeatherForecastViewModel> Get();
    }
}
