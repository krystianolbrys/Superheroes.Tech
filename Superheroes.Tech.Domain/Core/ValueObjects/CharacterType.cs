namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    public class CharacterType
    {
        // TODO - get rig of strings in code
        public static readonly CharacterType Hero = new CharacterType("Hero");
        public static readonly CharacterType Villain = new CharacterType("Villain");

        public string Name { get; }

        private static readonly Dictionary<string, CharacterType> _instances = new()
        {
            { "Hero", Hero },
            { "Villain", Villain }
        };

        private CharacterType(string name)
        {
            Name = name;
        }

        public static CharacterType FromKey(string keyName)
        {
            var match = _instances.Keys.FirstOrDefault(k => string.Equals(k, keyName, StringComparison.OrdinalIgnoreCase));

            if (match != null && _instances.TryGetValue(match, out var instance))
            {
                return instance;
            }

            throw new KeyNotFoundException($"Character type not found for key: {keyName}");
        }
    }
}
