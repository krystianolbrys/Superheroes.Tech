using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Domain.Core.Exceptions
{
    public class NoWeaknessSetException : BusinessException
    {
        public NoWeaknessSetException(CharacterEntity character)
            : base($"Weakness not found for character: {character.Name}")
        {
        }
    }
}

