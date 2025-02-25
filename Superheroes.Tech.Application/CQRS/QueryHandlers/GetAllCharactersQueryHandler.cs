using MediatR;
using Superheroes.Tech.Application.CQRS.Queries;
using Superheroes.Tech.Domain.Core.Entities;
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
            return data;
        }
    }
}
