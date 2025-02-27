using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;
using Superheroes.Tech.Domain.Validators;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class StandardBattleWithOneSideWeaknessStrategy : IBattleStrategy
    {
        private readonly IWeaknessValidator _weaknessValidator;

        public StandardBattleWithOneSideWeaknessStrategy(IWeaknessValidator weaknessValidator)
        {
            _weaknessValidator = weaknessValidator;
        }

        public int DesignedForNumberOfFighters => 2;

        public bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            return
               characters.Count() == this.DesignedForNumberOfFighters
               && characters.First().Type != characters.Last().Type
               && _weaknessValidator.IsWeaknessOneWayApplicable(characters);
        }

        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters)
        {
            var winner = characters.First(character => !character.HasWeaknessCharacter);

            return BattleResultVo.CreteResolved(this.GetType().Name, winner);
        }
    }
}
