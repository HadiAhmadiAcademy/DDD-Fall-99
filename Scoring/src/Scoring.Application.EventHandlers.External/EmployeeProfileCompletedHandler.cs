using System.Threading.Tasks;
using MassTransit;
using Scoring.Application.Contracts.Applicants;
using Scoring.Application.Contracts.Rules;

namespace Scoring.Application.EventHandlers.External
{
    public class EmployeeProfileCompletedHandler : IConsumer<EmployeeProfileCompleted>
    {
        private readonly IApplicantService _service;
        public EmployeeProfileCompletedHandler(IApplicantService service)
        {
            _service = service;
        }
        public Task Consume(ConsumeContext<EmployeeProfileCompleted> context)
        {
            var command = new DefineApplicantCommand()
            {
                HireDate = context.Message.HireDate,
                Firstname = context.Message.Firstname,
                Id = context.Message.EmployeeId,
                Lastname = context.Message.Lastname
            };
            return _service.DefineApplicant(command);
        }
    }
}