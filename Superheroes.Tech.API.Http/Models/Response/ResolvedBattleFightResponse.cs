namespace Superheroes.Tech.API.Http.Models.Response
{
    public class ResolvedBattleFightResponse
    {
        public ResolvedBattleFightResponse(string winner, string strategyKey)
        {
            Winner = winner;
            StrategyKey = strategyKey;
        }

        public string Winner { get; set; }
        public string StrategyKey { get; set; }
    }
}
