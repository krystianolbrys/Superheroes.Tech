using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class StandardCrossTypeBattleStrategy : IBattleStrategy
    {
        public int DesignedForHowManyFighters => throw new NotImplementedException();

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
