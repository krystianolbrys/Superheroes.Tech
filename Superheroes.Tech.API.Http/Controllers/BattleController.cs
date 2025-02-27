using MediatR;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Tech.API.Http.Models.Request;
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
        public async Task<ActionResult<ResolvedBattleFightResponse>> Get([FromQuery] BattleRequest dto, CancellationToken cts)
        {
            var command = new ExecuteBattleCommand([dto.Character, dto.Rival]);
            var result = await _mediator.Send(command, cts);

            if (result.Success)
            {
                return new ResolvedBattleFightResponse(result.CharacterEntity!.Name, result.StrategyKey);
            }

            // todo check that and catch other exceptions
            return BadRequest(new UnresolvedBattleFightResponse(result.FailReason!, result.StrategyKey));
        }
    }
}
