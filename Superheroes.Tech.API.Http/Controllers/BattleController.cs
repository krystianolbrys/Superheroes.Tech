using MediatR;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Tech.Application.CQRS.Queries;

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
        public async Task<IEnumerable<object>> Get(CancellationToken cts)
        {
            var data = await _mediator.Send(new GetAllCharactersQuery(), cts);

            return data.Select(character =>
            {
                var weaknessName = character.HasWeaknessCharacter ? character.Weakness.Name : null;
                return new { character.Name, weaknessName };
            });
        }
    }
}
