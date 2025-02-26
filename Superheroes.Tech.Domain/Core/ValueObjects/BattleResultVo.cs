using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    public class BattleResultVo
    {
        public BattleResultVo(bool success, CharacterEntity? characterEntity = null, string? failReason = null)
        {
            Success = success;
            CharacterEntity = characterEntity;
            FailReason = failReason;
        }

        public bool Success { get; private set; }
        public CharacterEntity? CharacterEntity { get; private set; }
        public string? FailReason { get; private set; }
    }
}
