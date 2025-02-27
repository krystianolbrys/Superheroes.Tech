using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class SameTypeBattleStrategy : IBattleStrategy
    {
        public int DesignedForNumberOfFighters => 2;

        public bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            return 
                characters.Count() == this.DesignedForNumberOfFighters
                && characters.First().Type == characters.Last().Type;
        }

        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters)
        {
            return BattleResultVo.CreteUnrosolved(this.GetType().Name, "characters of the same type should not fight");
        }
    }
}
