using System;

namespace Scoring.Application.Contracts.Applicants
{
    public class DefineApplicantCommand
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime HireDate { get; set; }
    }
}