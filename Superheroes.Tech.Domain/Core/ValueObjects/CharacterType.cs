namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    public class CharacterType
    {
        private static readonly string _heroKey = "Hero";
        private static readonly string _villainKey = "Villain";

        public static readonly CharacterType Hero = new CharacterType(_heroKey);
        public static readonly CharacterType Villain = new CharacterType(_villainKey);

        public string Name { get; }

        private static readonly Dictionary<string, CharacterType> _instances = new()
        {
            { _heroKey, Hero },
            { _villainKey, Villain }
        };

        private CharacterType(string name)
        {
            Name = name;
        }

        public static CharacterType FromKey(string candidateKey)
        {
            var match = _instances.Keys.FirstOrDefault(key => string.Equals(key, candidateKey, StringComparison.OrdinalIgnoreCase));

            if (match != null && _instances.TryGetValue(match, out var instance))
            {
                return instance;
            }

            throw new KeyNotFoundException($"Character type not found for key: {candidateKey}");
        }
    }
}
