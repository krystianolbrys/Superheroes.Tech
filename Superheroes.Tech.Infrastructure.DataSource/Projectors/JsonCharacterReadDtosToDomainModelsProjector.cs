using System.Text.Json;
using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;
using Superheroes.Tech.Infrastructure.DataSource.Models.CharactersJson;

namespace Superheroes.Tech.Infrastructure.DataSource.Projectors
{
    public class JsonCharacterReadDtosToDomainModelsProjector : IJsonCharacterReadDtosToDomainModelsProjector
    {
        public IEnumerable<CharacterEntity> Project(IEnumerable<CharacterReadDto> dtos)
        {
            var charactersWithoutWeakness = dtos.Where(d => d.Weakness == null);
            var others = dtos.Except(charactersWithoutWeakness).ToList();
            return [];
        }

        //private CharacterEntity Map(CharacterReadDto dto)
        //{
        //    return null;
        //}
    }
}
