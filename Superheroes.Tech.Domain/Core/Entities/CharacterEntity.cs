using Superheroes.Tech.Domain.Core.Enums;
using Superheroes.Tech.Domain.Core.Exceptions;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Core.Entities
{
    public class CharacterEntity
    {
        public CharacterEntity(string name, CharacterType type, ScoreVo score, CharacterEntity? weakness = null)
        {
            Name = name;
            Type = type;
            Score = score;
            _weakness = weakness;
        }

        private CharacterEntity? _weakness;

        public string Name { get; private set; }

        public CharacterType Type { get; private set; }

        public ScoreVo Score { get; private set; }

        public CharacterEntity Weakness
        {
            get => _weakness ?? throw new NoWeaknessSetException(this);
            private set => _weakness = value;
        }

        public bool HasWeaknessCharacter => _weakness != null;
    }
}