using FluentAssertions;
using NUnit.Framework;
using Superheroes.Tech.Domain.Core.Entities;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace BattleResultVoTests
{
    [TestFixture]
    public class BattleResultVoTests
    {
        private CharacterEntity _validCharacterEntity;
        private string _validStrategyKey;
        private string _validFailReason;

        [SetUp]
        public void SetUp()
        {
            _validCharacterEntity = this.CreateValidCharacterEntity();
            _validStrategyKey = "ValidStrategryKey1";
            _validFailReason = "ValidFailReason1";
        }


        [Test]
        public void CreateResolved_ShouldCreateCorrectBattleResultVo()
        {
            // Arrange & Act
            var result = BattleResultVo.CreteResolved(_validStrategyKey, _validCharacterEntity);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.CharacterEntity.Should().Be(_validCharacterEntity);
            result.FailReason.Should().BeNull();
            result.StrategyKey.Should().Be(_validStrategyKey);
        }

        [Test]
        public void CreateUnresolved_ShouldCreateCorrectBattleResultVo()
        {
            // Arrange & Act
            var result = BattleResultVo.CreteUnrosolved(_validStrategyKey, _validFailReason);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.CharacterEntity.Should().BeNull();
            result.FailReason.Should().Be(_validFailReason);
            result.StrategyKey.Should().Be(_validStrategyKey);
        }

        private CharacterEntity CreateValidCharacterEntity()
            => new CharacterEntity("CharacterName1", CharacterTypeVo.Hero, new ScoreVo(10));
    }
}

