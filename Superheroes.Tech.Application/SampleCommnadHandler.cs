using MediatR;

namespace Superheroes.Tech.Application
{
    public class SampleCommnadHandler : IRequestHandler<SampleCommand, int>
    {
        public async Task<int> Handle(SampleCommand request, CancellationToken cancellationToken)
        {
            return request.Value * 11;
        }
    }
}
