namespace Superheroes.Tech.Domain.Core.ValueObjects
{
    public class ScoreVo
    {
        public ScoreVo(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }

        public bool IsGreatherThan(ScoreVo comparisonObject) => this.Value > comparisonObject.Value;

        public bool AreEqual(ScoreVo comparisonObject) => this.Value == comparisonObject.Value;
    }
}
