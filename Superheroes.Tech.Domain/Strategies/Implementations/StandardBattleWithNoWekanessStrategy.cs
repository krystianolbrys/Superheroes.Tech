using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class StandardBattleWithNoWekanessStrategy : IBattleStrategy
    {
        public int DesignedForNumberOfFighters => 2;

        public bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            return
               characters.Count() == this.DesignedForNumberOfFighters
               && characters.First().Type != characters.Last().Type
               && !this.IsWeaknessOneWayApplicable(characters);
        }

        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters)
        {
            var winner = characters.OrderByDescending(character => character.Score.Value).First();

            return BattleResultVo.CreteResolved(this.GetType().Name, winner);
        }

        private bool IsWeaknessOneWayApplicable(IEnumerable<CharacterEntity> characters)
        {
            var characterWithWeeknesDefined =
                characters.Single(character => character.HasWeaknessCharacter);

            var characterWithoutWeeknesDefined =
                characters.Single(character => !character.HasWeaknessCharacter);

            if (characterWithWeeknesDefined.Weakness == characterWithoutWeeknesDefined)
            {
                return true;
            }

            return false;
        }
    }
}
