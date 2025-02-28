namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    public class CharacterTypeVo
    {
        private static readonly string _heroKey = "Hero";
        private static readonly string _villainKey = "Villain";

        public static readonly CharacterTypeVo Hero = new CharacterTypeVo(_heroKey);
        public static readonly CharacterTypeVo Villain = new CharacterTypeVo(_villainKey);

        public string Name { get; }

        private static readonly Dictionary<string, CharacterTypeVo> _instances = new()
        {
            { _heroKey, Hero },
            { _villainKey, Villain }
        };

        private CharacterTypeVo(string name)
        {
            Name = name;
        }

        public static CharacterTypeVo FromKey(string candidateKey)
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
