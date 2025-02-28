using FluentAssertions;
using NUnit.Framework;
using Superheroes.Tech.Domain.Core.Exceptions;

namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    [TestFixture]
    public class ScoreVoTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenValueIsZero()
        {
            // Arrange
            Action act = () => new ScoreVo(0);

            // Act & Assert
            act.Should().Throw<ScoreIsZeroOrNegativeException>();
        }

        [Test]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenValueIsNegative()
        {
            // Arrange
            Action act = () => new ScoreVo(-1);

            // Act & Assert
            act.Should().Throw<ScoreIsZeroOrNegativeException>();
        }

        [Test]
        public void Constructor_ShouldCreateInstance_WhenValueIsPositive()
        {
            // Arrange
            double validValue = 10.0;

            // Act
            var score = new ScoreVo(validValue);

            // Assert
            score.Value.Should().Be(validValue);
        }

        [Test]
        public void IsGreatherThan_ShouldReturnTrue_WhenFirstValueIsGreater()
        {
            // Arrange
            var score1 = new ScoreVo(10);
            var score2 = new ScoreVo(5);

            // Act
            bool result = score1.IsGreatherThan(score2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsGreatherThan_ShouldReturnFalse_WhenFirstValueIsLess()
        {
            // Arrange
            var score1 = new ScoreVo(5);
            var score2 = new ScoreVo(10);

            // Act
            bool result = score1.IsGreatherThan(score2);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsGreatherThan_ShouldReturnFalse_WhenValuesAreEqual()
        {
            // Arrange
            var score1 = new ScoreVo(10);
            var score2 = new ScoreVo(10);

            // Act
            bool result = score1.IsGreatherThan(score2);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void AreEqual_ShouldReturnTrue_WhenValuesAreEqual()
        {
            // Arrange
            var score1 = new ScoreVo(10);
            var score2 = new ScoreVo(10);

            // Act
            bool result = score1.AreEqual(score2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void AreEqual_ShouldReturnFalse_WhenValuesAreDifferent()
        {
            // Arrange
            var score1 = new ScoreVo(10);
            var score2 = new ScoreVo(5);

            // Act
            bool result = score1.AreEqual(score2);

            // Assert
            result.Should().BeFalse();
        }
    }
}
