using FluentAssertions;
using NUnit.Framework;
using Superheroes.Tech.Domain.Core.ValueObjects;

namespace CharacterTypeTests
{
    [TestFixture]
    public class CharacterTypeTests
    {
        [TestCaseSource(nameof(GetPositiveTestCaseData))]
        public void FromKey_ValidKey_ReturnsExpectedCharacterType(string inputKey, CharacterTypeVo expectedType)
        {
            // Arrange && Act
            var result = CharacterTypeVo.FromKey(inputKey);

            // Assert
            result.Should().Be(expectedType);
        }

        [TestCase("Unknown")]
        [TestCase("BadGuy")]
        [TestCase("heroo")]
        [TestCase("123")]
        [TestCase("")]
        [TestCase(null)]
        public void FromKey_InvalidKey_ThrowsKeyNotFoundException(string inputKey)
        {
            // Arrange
            Action action = () => CharacterTypeVo.FromKey(inputKey);

            // Act & Assert
            action.Should().Throw<KeyNotFoundException>();
        }

        private static IEnumerable<TestCaseData> GetPositiveTestCaseData()
        {
            yield return new TestCaseData("Hero", CharacterTypeVo.Hero);
            yield return new TestCaseData("hero", CharacterTypeVo.Hero);
            yield return new TestCaseData("HERO", CharacterTypeVo.Hero);
            yield return new TestCaseData("heRO", CharacterTypeVo.Hero);

            yield return new TestCaseData("Villain", CharacterTypeVo.Villain);
            yield return new TestCaseData("villain", CharacterTypeVo.Villain);
            yield return new TestCaseData("VILLAIN", CharacterTypeVo.Villain);
            yield return new TestCaseData("viLLAin", CharacterTypeVo.Villain);
        }
    }
}
