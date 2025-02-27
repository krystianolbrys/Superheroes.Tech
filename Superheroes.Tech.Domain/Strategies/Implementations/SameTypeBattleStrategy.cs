using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class SameTypeBattleStrategy : AbstractBattleStrategy
    {
        public override int DesignedForNumberOfFighters => 2;

        public override bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            return 
                characters.Count() == this.DesignedForNumberOfFighters
                && characters.First().Type == characters.Last().Type;
        }

        protected override BattleResultVo BattleStepsImplementation(IEnumerable<CharacterEntity> characters)
        {
            return BattleResultVo.CreteUnrosolved(this.GetName, "characters of the same type should not fight");
        }
    }
}
