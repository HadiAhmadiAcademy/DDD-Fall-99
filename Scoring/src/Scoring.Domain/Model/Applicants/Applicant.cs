using System;
using Framework.Domain;

namespace Scoring.Domain.Model.Applicants
{
    public class Applicant : AggregateRoot<ApplicantId>
    {
        public Name Name { get; private  set; }
        public DateTime HireDate { get; private set; }
        public Applicant(ApplicantId id, Name applicantName, DateTime hireDate)
        {
            Id = id;
            Name = applicantName;
            HireDate = hireDate;
        }
    }
}