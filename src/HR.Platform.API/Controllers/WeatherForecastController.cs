using HR.Platform.Application.BusinessLogic.Applicants.Commands.CreateApplicant;
using HR.Platform.Application.Common.Interfaces;
using HR.Platform.Domain.Entities;
using HR.Platform.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.Platform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHRDbContext _dbContext;
        private readonly ISender _sender;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHRDbContext dbContext, ISender sender)
        {
            //var sfsfd = dbContext.Applicants.Where(_ => true).ToListAsync().GetAwaiter().GetResult();
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {




            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> Post([FromBody] CreateApplicantCommand createApplicantCommand)
        {
            var gg = await _sender.Send(createApplicantCommand);
            var ff = await _dbContext.Applicants.Where(_ => true).ToListAsync();



            return Ok("dfgdfgdfg");
        }
    }
}