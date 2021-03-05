using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public readonly CursosOnlineContext _contex;
        public WeatherForecastController(CursosOnlineContext context, ILogger<WeatherForecastController> logger)
        {
            _contex = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Curso> Get()
        {
            return _contex.Curso.ToList();
        }
    }
}
