namespace Superheroes.Tech.Domain.Core.Exceptions
{
    public class ScoreIsZeroOrNegativeException : BusinessException
    {
        public ScoreIsZeroOrNegativeException(string message) : base(message) { }
    }
}
