using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies.Implementations
{
    public class StandardBattleWithOneSideWeaknessStrategy : IBattleStrategy
    {
        public int DesignedForNumberOfFighters => 2;

        public bool IsApplicable(IEnumerable<CharacterEntity> characters)
        {
            return
               characters.Count() == this.DesignedForNumberOfFighters
               && characters.First().Type != characters.Last().Type
               && this.IsWeaknessApplicable(characters);
        }

        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters)
        {
            return new BattleResultVo(false, null, "StandardBattleWithOneSideWeaknessStrategy");
        }

        private bool IsWeaknessApplicable(IEnumerable<CharacterEntity> characters)
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
