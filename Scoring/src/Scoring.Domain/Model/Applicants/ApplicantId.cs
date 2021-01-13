namespace Scoring.Domain.Model.Applicants
{
    public class ApplicantId
    {
        public long Value { get; private set; }
        public ApplicantId(long value)
        {
            Value = value;
        }

    }
}