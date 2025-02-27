using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;
using Superheroes.Tech.Domain.Validators;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class StandardBattleWithNoWekanessStrategy : AbstractBattleStrategy
    {
        private readonly IWeaknessValidator _weaknessValidator;

        public StandardBattleWithNoWekanessStrategy(IWeaknessValidator weaknessValidator)
        {
            _weaknessValidator = weaknessValidator;
        }

        public override int DesignedForNumberOfFighters => 2;

        public override bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            return
               characters.Count() == this.DesignedForNumberOfFighters
               && characters.First().Type != characters.Last().Type
               && !_weaknessValidator.IsWeaknessOneWayApplicable(characters);
        }

        protected override BattleResultVo BattleStepsImplementation (IEnumerable<CharacterEntity> characters)
        {
            var winner = characters.OrderByDescending(character => character.Score.Value).First();

            return BattleResultVo.CreteResolved(this.GetType().Name, winner);
        }
    }
}
