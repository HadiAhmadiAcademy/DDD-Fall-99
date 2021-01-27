using System;

namespace Scoring.Application.EventHandlers.External
{
    public class EmployeeProfileCompleted       //TODO: move to HR context
    {
        public long EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime HireDate { get; set; }

        //....
        //....
    }
}