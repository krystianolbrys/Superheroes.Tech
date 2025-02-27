namespace Superheroes.Tech.Domain.Core.Exceptions
{
    public class CharacterNotFoundExeception : BusinessException
    {
        public CharacterNotFoundExeception(string name): base($"Character not found: {name}") { }
    }
}
