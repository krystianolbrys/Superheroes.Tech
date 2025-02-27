using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Domain.Validators
{
    public interface IWeaknessValidator
    {
        public bool IsWeaknessOneWayApplicable(IEnumerable<CharacterEntity> characters);
    }

    public class WeaknessValidator : IWeaknessValidator
    {
        public bool IsWeaknessOneWayApplicable(IEnumerable<CharacterEntity> characters)
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
