using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    public class BattleResultVo
    {
        private BattleResultVo(string strategyKey, bool success, CharacterEntity? characterEntity, string? failReason)
        {
            StrategyKey = strategyKey;
            Success = success;
            CharacterEntity = characterEntity;
            FailReason = failReason;
        }

        public bool Success { get; private set; }
        public CharacterEntity? CharacterEntity { get; private set; }
        public string? FailReason { get; private set; }
        public string StrategyKey { get; private set; }

        public static BattleResultVo CreteUnrosolved(string strategyKey, string reason)
            => new BattleResultVo(strategyKey, false, null, reason);

        public static BattleResultVo CreteResolved(string strategyKey, CharacterEntity? winner)
            => new BattleResultVo(strategyKey, true, winner, null);
    }
}
