using MediatR;

namespace Superheroes.Tech.Application
{
    public class SampleCommand : IRequest<int>
    {
        public SampleCommand(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
    }
}
