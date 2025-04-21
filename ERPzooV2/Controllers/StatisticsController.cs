using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IZooStatisticsService _svc;
        public StatisticsController(IZooStatisticsService svc) => _svc = svc;

        [HttpGet]
        public IActionResult Get() => Ok(_svc.GetStatistics());
    }
}
