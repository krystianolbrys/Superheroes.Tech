using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class SingleWeaknessBattleStrategy : IBattleStrategy
    {
        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters)
        {
            throw new NotImplementedException();
        }

        public bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            throw new NotImplementedException();
        }
    }
}
