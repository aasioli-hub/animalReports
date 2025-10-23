using Microsoft.AspNetCore.Mvc;
using Prototipo.Api.Model;
using Prototipo.Api.Services.Interfaces;
using Prototipo.Service.Services.Interfaces;

namespace Prototipo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController: ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPippoService _service;
        private readonly ICategoryService _serviceCategory;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IPippoService service,
            ICategoryService serviceCategory)
        {
            _logger = logger;
            _service = service;
            _serviceCategory = serviceCategory;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetByFilter([FromQuery] PippoFilter filter)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add([FromBody] PippoDTO addEntity)
        {
            _serviceCategory.GetName();
            _service.Add(addEntity);

            _logger.LogInformation("new reuest pippo");

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _logger.LogInformation("request ok pippo");

            return Created("WeatherForecast/1", 1);
        }

        [HttpPatch]
        public IActionResult Update([FromBody] PippoUpdateDTO updateEntity)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return NoContent();
        }
    }
}
