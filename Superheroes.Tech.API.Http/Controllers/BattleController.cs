using MediatR;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Tech.Application;

namespace Superheroes.Tech.API.Http.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly ILogger<BattleController> _logger;
        private readonly IMediator _mediator;

        public BattleController(ILogger<BattleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<int[]> Get(CancellationToken cts)
        {
            var data = await _mediator.Send(new SampleCommand(13), cts);
            return [.. Enumerable.Range(1, 5).ToArray(), data];
        }
    }
}
