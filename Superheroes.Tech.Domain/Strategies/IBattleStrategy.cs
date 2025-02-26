using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace Superheroes.Tech.Domain.Strategies
{
    public interface IBattleStrategy
    {
        public int DesignedForNumberOfFighters { get; }

        public bool IsApplicable(IEnumerable<CharacterEntity> characters);

        public BattleResultVo Execute(IEnumerable<CharacterEntity> characters);
    }
}
