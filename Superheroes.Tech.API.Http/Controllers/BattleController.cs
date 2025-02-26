using MediatR;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Tech.API.Http.Models.Response;
using Superheroes.Tech.Application.CQRS.Commands;

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
        public async Task<ActionResult<BattleFightResponse>> Get(CancellationToken cts)
        {
            var character = "thor";
            var rival = "thanos";

            var command = new ExecuteBattleCommand([character, rival]);
            var result = await _mediator.Send(command, cts);

            if (result.Success)
            {
                return new BattleFightResponse { Winner = result.CharacterEntity!.Name };
            }

            // todo check that and catch other exceptions
            return BadRequest(result.FailReason);
        }
    }
}
