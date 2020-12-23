namespace Scoring.Application.Contracts.Rules
{
    public class DefineRuleCommand
    {
        public string Title { get; set; }
        public bool IsIncreasing { get; set; }
        public int CalculationValue { get; set; }
        public CriteriaData Criteria { get; set; }
    }
    public class CriteriaData
    {
        public string Type { get; set; }
    }

    public class CompositeCriteria : CriteriaData
    {
        public CriteriaData Left { get; set; }
        public CriteriaData Right { get; set; }
    }

    public class ConcreteCriteria : CriteriaData
    {
        public object Value { get; set; }
    }
}