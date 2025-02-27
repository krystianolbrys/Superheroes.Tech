using MediatR;
using Superheroes.Tech.Application.CQRS.Commands;
using Superheroes.Tech.Domain.Core.ValueObjects;
using Superheroes.Tech.Domain.Processors;
using Superheroes.Tech.Domain.Strategies;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;

namespace Superheroes.Tech.Application.CQRS.CommandHandlers
{
    public class ExecuteBattleCommandHandler : IRequestHandler<ExecuteBattleCommand, BattleResultVo>
    {
        private readonly ICharactersDataProvider _dataProvider;
        private readonly IEnumerable<IBattleStrategy> _strategies;

        public ExecuteBattleCommandHandler(ICharactersDataProvider dataProvider, IEnumerable<IBattleStrategy> strategies)
        {
            _dataProvider = dataProvider;
            _strategies = strategies;
        }

        public async Task<BattleResultVo> Handle(ExecuteBattleCommand request, CancellationToken cancellationToken)
        {
            var characters = await _dataProvider.GetByNames(request.CharacterNames);

            var processor = new BattleProcessor(_strategies);
            var result = processor.Fight(characters);

            return result;
        }
    }
}
