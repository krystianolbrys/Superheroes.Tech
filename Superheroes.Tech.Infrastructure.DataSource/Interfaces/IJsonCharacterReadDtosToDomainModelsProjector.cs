using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Infrastructure.DataSource.Models.CharactersJson;

namespace Superheroes.Tech.Infrastructure.DataSource.Interfaces
{
    public interface IJsonCharacterReadDtosToDomainModelsProjector
    {
        public IEnumerable<CharacterEntity> Project(IEnumerable<CharacterReadDto> dtos);
    }
}
