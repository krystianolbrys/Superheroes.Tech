using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.Exceptions;
using Superheroes.Tech.Domain.Core.ValueObjects;
using Superheroes.Tech.Domain.Strategies;

namespace Superheroes.Tech.Domain.Processors
{
    public class BattleProcessor
    {
        private readonly IEnumerable<AbstractBattleStrategy> _strategies;

        public BattleProcessor(IEnumerable<AbstractBattleStrategy> strategies)
        {
            _strategies = strategies;
        }

        public BattleResultVo Fight(IEnumerable<CharacterEntity> characters)
        {
            var strategy = this.SelectApplicableStrategyOrThrow(characters);
            var result = strategy.Execute(characters);

            return result;
        }

        private AbstractBattleStrategy SelectApplicableStrategyOrThrow(IEnumerable<CharacterEntity> characters)
        {
            var apllicableStrategies =
                _strategies.Where(strategy => strategy.IsApplicable(characters)).ToList();

            if (!apllicableStrategies.Any())
            {
                throw new NoStrategyApplicableForBattleException("Here all needed data to log what has happened");
            }

            if (apllicableStrategies.Count() > 1)
            {
                throw new MultipleStrategyAvailableException("Here all needed data to log what has happened");
            }

            return apllicableStrategies.Single();
        }
    }
}
