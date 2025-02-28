namespace Superheroes.Tech.Domain.Core.Exceptions
{
    public class MultipleStrategyAvailableException : BusinessException
    {
        public MultipleStrategyAvailableException(string message) : base(message)
        {
        }
    }
}
