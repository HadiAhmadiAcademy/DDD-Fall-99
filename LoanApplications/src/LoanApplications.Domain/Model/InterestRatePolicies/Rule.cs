namespace LoanApplications.Domain.Model.InterestRatePolicies
{
    public class Rule
    {
        public Range<Point> Range { get; private set; }
        public Percent Percent { get; private set; }
        public Rule(Range<Point> range, Percent percent)
        {
            Range = range;
            Percent = percent;
        }
        public bool HasConflictWith(Rule rule)
        {
            return Range.IsOverlapWith(rule.Range);
        }
        public bool AppliesTo(Point point)
        {
            return this.Range.Contains(point);
        }
    }
}