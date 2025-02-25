using System.Text.Json;
using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Infrastructure.DataSource.Configurations;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;
using Superheroes.Tech.Infrastructure.DataSource.Models.CharactersJson;

namespace Superheroes.Tech.Infrastructure.DataSource.Implementations
{
    public class CharastersJsonStaticFileDataProvider : ICharactersDataProvider
    {
        private readonly CharactersJsonStaticFileConfiguration _configuration;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CharastersJsonStaticFileDataProvider(CharactersJsonStaticFileConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(configuration));
            _configuration = configuration;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<IEnumerable<CharacterEntity>> GetAll()
        {
            var dtos = await this.ReadFileRaw();

            // only test purpose
            Console.WriteLine(JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true}));

            // project from DTO to Core Entity objects
            return [];
        }

        public async Task<CharacterEntity> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<CharacterReadDto>> ReadFileRaw()
        {
            using FileStream stream = File.OpenRead(_configuration.FilePath);
            using StreamReader reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            var deserializedArray = JsonSerializer.Deserialize<RootReadDto>(content, _jsonSerializerOptions);

            return deserializedArray?.Items ?? [];
        }
    }
}
