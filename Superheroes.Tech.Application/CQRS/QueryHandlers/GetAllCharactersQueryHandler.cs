using System.Text.Json;
using MediatR;
using Superheroes.Tech.Application.CQRS.Queries;
using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.Processors;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;

namespace Superheroes.Tech.Application.CQRS.QueryHandlers
{
    public class GetAllCharactersQueryHandler : IRequestHandler<GetAllCharactersQuery, IEnumerable<CharacterEntity>>
    {
        private readonly ICharactersDataProvider _dataProvider;

        public GetAllCharactersQueryHandler(ICharactersDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IEnumerable<CharacterEntity>> Handle(GetAllCharactersQuery request, CancellationToken cancellationToken)
        {
            var data = await _dataProvider.GetAll();
            var thor = data.First(d => d.EqualsByName("thor"));
            var thanos = data.First(d => d.EqualsByName("thanos"));

            var processor = new BattleProcessor();
            var result1 = processor.Fight(thor, thanos);

            return data;
        }
    }
}
