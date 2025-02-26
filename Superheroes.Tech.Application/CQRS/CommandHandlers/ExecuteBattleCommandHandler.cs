using System.Text.Json;
using MediatR;
using Superheroes.Tech.Application.CQRS.Commands;
using Superheroes.Tech.Domain.Core.ValueObjects;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;

namespace Superheroes.Tech.Application.CQRS.CommandHandlers
{
    public class ExecuteBattleCommandHandler : IRequestHandler<ExecuteBattleCommand, BattleResultVo>
    {
        private readonly ICharactersDataProvider _dataProvider;

        public ExecuteBattleCommandHandler(ICharactersDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<BattleResultVo> Handle(ExecuteBattleCommand request, CancellationToken cancellationToken)
        {
            var characters = await _dataProvider.GetByNames(request.CharacterNames);

            Console.WriteLine(JsonSerializer.Serialize(characters.Select(d => d.Name)));

            return new BattleResultVo(false, null, "implementacja spadła z rowerka");
        }
    }
}
