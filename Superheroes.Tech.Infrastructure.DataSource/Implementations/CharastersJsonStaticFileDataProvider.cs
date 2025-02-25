using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Infrastructure.DataSource.Configurations;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;

namespace Superheroes.Tech.Infrastructure.DataSource.Implementations
{
    public class CharastersJsonStaticFileDataProvider : ICharactersDataProvider
    {
        private readonly CharactersJsonStaticFileConfiguration _configuration;

        public CharastersJsonStaticFileDataProvider(CharactersJsonStaticFileConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(configuration));
            _configuration = configuration;
        }

        public async Task<IEnumerable<CharacterEntity>> GetAll()
        {
            return [];
        }

        public async Task<CharacterEntity> GetByName(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
