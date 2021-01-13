namespace Scoring.Domain.Model.Applicants
{
    public class Name
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}