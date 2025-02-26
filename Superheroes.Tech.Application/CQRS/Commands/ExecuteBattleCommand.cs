using MediatR;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Application.CQRS.Commands
{
    public class ExecuteBattleCommand : IRequest<BattleResultVo> {
        public IEnumerable<string> CharacterNames { get; private set; }

        public ExecuteBattleCommand(IEnumerable<string> characterNames)
        {
            CharacterNames = characterNames;
        }
    }
}
