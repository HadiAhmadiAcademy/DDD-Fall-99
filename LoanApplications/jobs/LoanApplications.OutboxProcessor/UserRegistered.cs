using System;
using Framework.Domain;

namespace LoanApplications.OutboxProcessor
{
    public class UserRegistered : DomainEvent
    {
        public string Username { get; set; }
    }
}