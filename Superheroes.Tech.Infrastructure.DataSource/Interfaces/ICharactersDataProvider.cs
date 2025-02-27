using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Infrastructure.DataSource.Interfaces
{
    public interface ICharactersDataProvider
    {
        public Task<IEnumerable<CharacterEntity>> GetAll();

        public Task<CharacterEntity> GetByNameOrThrow(string Name);

        public Task<IEnumerable<CharacterEntity>> GetByNamesOrThrow(IEnumerable<string> names);
    }
}
