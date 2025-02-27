using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies
{
    public abstract class AbstractBattleStrategy
    {
        public abstract int DesignedForNumberOfFighters { get; }

        public abstract bool IsApplicable(IEnumerable<CharacterEntity> characters);

        protected abstract BattleResultVo BattleStepsImplementation(IEnumerable<CharacterEntity> characters);

        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters)
        {
            if (!this.IsApplicable(characters))
            {
                throw new InvalidOperationException("Execution proceeded with improper use of IsApplicable or system design flaw");
            }

            return this.BattleStepsImplementation(characters);
        }
    }
}
