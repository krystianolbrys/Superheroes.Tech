namespace Superheroes.Tech.Infrastructure.DataSource.Configurations
{
    public class CharactersJsonStaticFileConfiguration
    {
        public CharactersJsonStaticFileConfiguration(string filePath)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(filePath);
            FilePath = filePath;
        }

        public string FilePath { get; private set; }
    }
}
