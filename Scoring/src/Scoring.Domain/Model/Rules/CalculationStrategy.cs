namespace Scoring.Domain.Model.Rules
{
    public class CalculationStrategy
    {
        public static CalculationStrategy None = new CalculationStrategy(0);
        public int Value { get; private set; }
        private CalculationStrategy(int value)
        {
            Value = value;
        }
        public static CalculationStrategy IncreasePointsTo(int value)
        {
            return new CalculationStrategy(value);
        }
        public static CalculationStrategy DecreasePointsTo(int value)
        {
            return new CalculationStrategy(value * -1);
        }
    }
}