namespace Superheroes.Tech.API.Http.Models.Response
{
    public class UnresolvedBattleFightResponse
    {
        public UnresolvedBattleFightResponse(string reason, string strategyKey)
        {
            Reason = reason;
            StrategyKey = strategyKey;
        }

        public string Reason { get; set; }
        public string StrategyKey { get; set; }
    }
}
