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
            var charactersWithWeakness = dtos.Except(charactersWithoutWeakness).ToList();

            var part1 = charactersWithoutWeakness.Select(this.Map);
            var part2 = charactersWithWeakness.Select(dto => this.FindMatchAndMap(dto, part1));

            return [.. part1, .. part2];
        }

        private CharacterEntity Map(CharacterReadDto dto)
        {
            var score = new ScoreVo(dto.Score!.Value);
            var type = CharacterType.FromKey(dto.Type!);
            return new CharacterEntity(dto.Name!, type, score);
        }

        private CharacterEntity FindMatchAndMap(CharacterReadDto dto, IEnumerable<CharacterEntity> existing)
        {
            var foundWekness = existing.FirstOrDefault(character => character.EqualsByName(dto.Weakness!));

            var score = new ScoreVo(dto.Score!.Value);
            var type = CharacterType.FromKey(dto.Type!);
            return new CharacterEntity(dto.Name!, type, score, foundWekness);
        }
    }
}
