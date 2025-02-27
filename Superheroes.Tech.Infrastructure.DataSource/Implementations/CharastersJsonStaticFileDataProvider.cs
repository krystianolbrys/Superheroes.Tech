using System.Text.Json;
using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.Exceptions;
using Superheroes.Tech.Infrastructure.DataSource.Configurations;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;
using Superheroes.Tech.Infrastructure.DataSource.Models.CharactersJson;

namespace Superheroes.Tech.Infrastructure.DataSource.Implementations
{
    public class CharastersJsonStaticFileDataProvider : ICharactersDataProvider
    {
        private readonly IJsonCharacterReadDtosToDomainModelsProjector _projector;
        private readonly CharactersJsonStaticFileConfiguration _configuration;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CharastersJsonStaticFileDataProvider(CharactersJsonStaticFileConfiguration configuration, IJsonCharacterReadDtosToDomainModelsProjector projector)
        {
            ArgumentNullException.ThrowIfNull(nameof(configuration));
            ArgumentNullException.ThrowIfNull(nameof(projector));
            _projector = projector;
            _configuration = configuration;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<IEnumerable<CharacterEntity>> GetAll()
        {
            var dtos = await this.ReadDtosFromRawFile();
            var characters = _projector.Project(dtos);
            return characters;
        }

        public async Task<CharacterEntity> GetByNameOrThrow(string name)
        {
            var characters = await this.GetAll();
            var candidate = characters.FirstOrDefault(character => character.EqualsByName(name));

            return candidate == null
                ? throw new CharacterNotFoundExeception(name)
                : candidate;
        }

        public async Task<IEnumerable<CharacterEntity>> GetByNamesOrThrow(IEnumerable<string> names)
        {
            var characters = await this.GetAll();

            var foundCharacters = names.Select(name => characters.FirstOrDefault(character => character.EqualsByName(name)))
                .Where(character => character != null);

            if (foundCharacters.Count() != names.Count())
            {
                throw new CharacterNotFoundExeception("Not all charactes found - add intercest which specific");
            }

            return foundCharacters!;
        }

        private async Task<IEnumerable<CharacterReadDto>> ReadDtosFromRawFile()
        {
            using FileStream stream = File.OpenRead(_configuration.FilePath);
            using StreamReader reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            var deserializedArray = JsonSerializer.Deserialize<RootReadDto>(content, _jsonSerializerOptions);

            return deserializedArray?.Items ?? [];
        }
    }
}
