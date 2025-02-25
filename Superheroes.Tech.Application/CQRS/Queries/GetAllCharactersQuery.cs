using MediatR;
using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Application.CQRS.Queries
{
    public class GetAllCharactersQuery : IRequest<IEnumerable<CharacterEntity>> { }
}
