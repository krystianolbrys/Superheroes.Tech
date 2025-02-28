namespace Superheroes.Tech.Domain.Core.Exceptions
{
    public class NoStrategyApplicableForBattleException : BusinessException
    {
        public NoStrategyApplicableForBattleException(string message) : base(message)
        {
        }
    }
}
