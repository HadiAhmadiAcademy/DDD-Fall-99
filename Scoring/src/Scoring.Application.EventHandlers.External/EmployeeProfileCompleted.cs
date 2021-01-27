using System;

namespace Scoring.Application.EventHandlers.External
{
    public class EmployeeProfileCompleted       //TODO: move to HR context and install it as nuget package here
    {
        public long EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime HireDate { get; set; }
        //....
        //....
    }
}