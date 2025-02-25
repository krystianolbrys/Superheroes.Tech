using Microsoft.AspNetCore.Mvc;

namespace Superheroes.Tech.API.Http.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly ILogger<BattleController> _logger;

        public BattleController(ILogger<BattleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int[] Get()
        {
            return Enumerable.Range(1, 5).ToArray();
        }
    }
}
